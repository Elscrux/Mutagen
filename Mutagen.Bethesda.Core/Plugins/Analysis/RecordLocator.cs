using System.Collections.Immutable;
using System.IO.Abstractions;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Meta;
using Noggog;
using Mutagen.Bethesda.Plugins.Masters;
using Mutagen.Bethesda.Plugins.Order;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Utility;

namespace Mutagen.Bethesda.Plugins.Analysis;

public sealed class RecordLocator
{
    private readonly FileLocationConstructor _locs;
    private readonly RecordInterest? _interest;
    private ImmutableStack<GroupLocationMarker> _parentGroupLocations = ImmutableStack<GroupLocationMarker>.Empty;
    
    private RecordLocator(FileLocationConstructor locs, RecordInterest? interest)
    {
        _locs = locs;
        _interest = interest;
    }

    #region Get File Locations
    
    internal class FileLocationConstructor
    {
        public Dictionary<FormKey, (RangeInt64 Range, IEnumerable<GroupLocationMarker> GroupPositions, RecordType Record)> FromFormKeys = new();
        public List<long> FromStartPositions = new();
        public List<long> FromEndPositions = new();
        public List<RecordLocationMarker> FormKeys = new();
        public List<GroupLocationMarker> GrupLocations = new();
        public FormKey LastParsed;
        public long LastLoc;
        public GameConstants MetaData { get; }
        public Func<IMutagenReadStream, MajorRecordHeader, bool>? AdditionalCriteria;

        public FileLocationConstructor(GameConstants metaData)
        {
            MetaData = metaData;
        }

        public void Add(
            FormKey formKey,
            RecordType record,
            ImmutableStack<GroupLocationMarker> parentGrupLocations,
            RangeInt64 section)
        {
            FromFormKeys[formKey] = (section, parentGrupLocations, record);
            FromStartPositions.Add(section.Min);
            FromEndPositions.Add(section.Max);
            FormKeys.Add(new(formKey, section, record));
            LastParsed = formKey;
            LastLoc = section.Min;
        }
    }

    public static RecordLocatorResults GetLocations(
        ModPath filePath,
        GameRelease release,
        ILoadOrderGetter<IModFlagsGetter>? loadOrder,
        RecordInterest? interest = null,
        IFileSystem? fileSystem = null)
    {
        using var stream = new MutagenBinaryReadStream(
            filePath,
            new ParsingMeta(
                release, 
                filePath.ModKey,
                SeparatedMasterPackage.Factory(release, filePath, loadOrder, fileSystem)),
            fileSystem: fileSystem);
        return GetLocations(stream, interest);
    }

    public static RecordLocatorResults GetLocations(
        ModPath filePath,
        GameConstants constants,
        IReadOnlySeparatedMasterPackage masters,
        RecordInterest? interest = null,
        IFileSystem? fileSystem = null)
    {
        using var stream = new MutagenBinaryReadStream(
            filePath,
            new ParsingMeta(
                constants, 
                filePath.ModKey,
                masters),
            fileSystem: fileSystem);
        return GetLocations(stream, interest);
    }

    public static RecordLocatorResults GetLocations(
        IMutagenReadStream reader,
        RecordInterest? interest = null,
        Func<IMutagenReadStream, MajorRecordHeader, bool>? additionalCriteria = null)
    {
        FileLocationConstructor ret = new FileLocationConstructor(reader.MetaData.Constants)
        {
            AdditionalCriteria = additionalCriteria,
        };
        var locator = new RecordLocator(ret, interest);
        return locator.Locate(new MutagenFrame(reader));
    }

    private RecordLocatorResults Locate(MutagenFrame reader)
    {
        reader.ReadModHeaderFrame();

        while (!reader.Complete)
        {
            var groupHeader = reader.GetGroupHeader();
            if (groupHeader.GroupType != 0)
            {
                throw new MalformedDataException($"Unexpected group type at top level: {groupHeader.GroupType}");
            }

            PushGroup(groupHeader);
            ParseTopLevelGroup(
                reader: reader.SpawnWithLength(groupHeader.TotalLength),
                groupPin: groupHeader,
                nesting: null);
            _parentGroupLocations = _parentGroupLocations.Pop();
        }

        return new RecordLocatorResults(_locs);
    }

    private bool IsInterested(RecordType grupRec)
    {
        return _interest?.IsInterested(grupRec) ?? true;
    }

    private bool CheckAdditionalCriteria(
        MutagenFrame reader,
        MajorRecordHeader majorRecord)
    {
        if (_locs.AdditionalCriteria != null)
        {
            var pos = reader.Position;
            if (!_locs.AdditionalCriteria(reader, majorRecord))
            {
                reader.Position = pos;
                return false;
            }
            reader.Position = pos;
        }

        return true;
    }

    private void ParseTopLevelGroup(
        MutagenFrame reader,
        GroupPinHeader groupPin,
        GroupNesting? nesting)
    {
        reader.Position += groupPin.HeaderLength;

        using var frame = MutagenFrame.ByFinalPosition(reader, reader.Position + groupPin.ContentLength);
        
        bool registered = false;
        while (!frame.Complete)
        {
            MajorRecordHeader majorRecordMeta = frame.GetMajorRecordHeader();
            var targetRec = majorRecordMeta.RecordType;
            
            if (frame.TryGetGroupHeader(out var followupNestedGroup)
                && followupNestedGroup.CanHaveSubGroups)
            {
                var nestedGroupType = followupNestedGroup.GroupType;
                var nextNesting = nesting?.Underneath.FirstOrDefault(x => x.GroupType == nestedGroupType) 
                                  ?? reader.MetaData.Constants.GroupConstants.TryGetNesting(nestedGroupType);
                if (nextNesting == null)
                {
                    throw new MalformedDataException($"Encountered nested group, but it was not registered: {followupNestedGroup.GroupType} was underneath {groupPin.GroupType}");
                }
                HandleGroup(
                    frame: frame.SpawnWithLength(followupNestedGroup.TotalLength),
                    groupPin: followupNestedGroup,
                    nesting: nextNesting);
                continue;
            }

            if (!CheckAdditionalCriteria(reader, majorRecordMeta))
            {
                reader.Position += majorRecordMeta.TotalLength;
                continue;
            }
            
            if (IsInterested(targetRec))
            {
                var pos = reader.Position;
                var currentFormKey = FormKey.Factory(reader.MetaData.MasterReferences, majorRecordMeta.FormID);

                _locs.Add(
                    formKey: currentFormKey,
                    record: targetRec,
                    parentGrupLocations: _parentGroupLocations,
                    section: new RangeInt64(pos, pos + majorRecordMeta.TotalLength - 1));

                if (!registered)
                {
                    RegisterGroupLocations();
                    registered = true;
                }
            }
            reader.Position += majorRecordMeta.TotalLength;
        }
    }

    private void RegisterGroupLocations()
    {
        foreach (var location in _parentGroupLocations)
        {
            if (!location.Registered)
            {
                _locs.GrupLocations.Add(location);
                location.Registered = true;
            }
        }
    }

    private void PushGroup(GroupPinHeader groupPin)
    {
        var register = new GroupLocationMarker(groupPin, _parentGroupLocations);
        _parentGroupLocations = _parentGroupLocations.Push(register);
        if (_interest == null)
        {
            _locs.GrupLocations.Add(register);
        }
    }

    private void HandleGroup(
        MutagenFrame frame,
        GroupPinHeader groupPin,
        GroupNesting nesting)
    {
        PushGroup(groupPin);
        if (nesting.Underneath.Length == 0
            || nesting.HasTopLevelRecordType)
        {
            ParseTopLevelGroup(
                reader: frame,
                nesting: nesting,
                groupPin: groupPin);
        }
        else
        {
            frame.Position += _locs.MetaData.GroupConstants.HeaderLength;
            while (!frame.Complete)
            {
                var groupMeta = frame.GetGroupHeader();
                var targetNesting = nesting.Underneath.FirstOrDefault(x => x.GroupType == groupMeta.GroupType);
                if (targetNesting == null)
                {
                    throw new MalformedDataException($"Encountered nested group, but it was not registered: {groupMeta.GroupType} was underneath {groupPin.GroupType}");
                }
                HandleGroup(frame.SpawnWithLength(groupMeta.TotalLength), groupMeta, targetNesting);
            }
        }
        _parentGroupLocations = _parentGroupLocations.Pop();
    }
    #endregion

    #region Base GRUP Iterator
    public static IEnumerable<(FormKey FormKey, long Position)> ParseTopLevelGRUP(
        IMutagenReadStream reader,
        bool checkOverallGrupType = true)
    {
        var groupMeta = reader.GetGroupHeader();
        var targetRec = groupMeta.ContainedRecordType;
        if (!groupMeta.IsGroup)
        {
            throw new ArgumentException();
        }

        reader.Position += groupMeta.HeaderLength;

        using (var frame = MutagenFrame.ByFinalPosition(reader, reader.Position + groupMeta.ContentLength))
        {
            while (!frame.Complete)
            {
                var recordLocation = reader.Position;
                MajorRecordHeader majorMeta = reader.GetMajorRecordHeader();
                if (majorMeta.RecordType != targetRec)
                {
                    var subGroupMeta = reader.GetGroupHeader();
                    if (subGroupMeta.CanHaveSubGroups)
                    {
                        reader.Position += subGroupMeta.TotalLength;
                        continue;
                    }
                    else if (checkOverallGrupType)
                    {
                        throw new ArgumentException($"Target Record {targetRec} at {frame.Position} did not match its containing GRUP: {subGroupMeta.ContainedRecordType}");
                    }
                }

                var formKey = FormKey.Factory(reader.MetaData.MasterReferences, majorMeta.FormID);
                var len = majorMeta.TotalLength;
                yield return (
                    formKey,
                    recordLocation);
                reader.Position += len;
            }
        }
    }
    #endregion
}