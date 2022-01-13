using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Furniture
    {
        [Flags]
        public enum MajorFlag
        {
            IsPerch = 0x0000_0080,
            HasDistantLOD = 0x0000_8000,
            RandomAnimStart = 0x0001_0000,
            IsMarker = 0x0080_0000,
            PowerArmor = 0x0200_0000,
            MustExitToTalk = 0x1000_0000,
            ChildCanUse = 0x2000_0000
        }

        [Flags]
        public enum Flag : uint
        {
            IgnoredBySandbox = 0x0000_0002,
        }

        [Flags]
        public enum ActiveMarkers : uint
        {
            InteractionPoint0 = 0x00000001,
            InteractionPoint1 = 0x00000002,
            InteractionPoint2 = 0x00000004,
            InteractionPoint3 = 0x00000008,
            InteractionPoint4 = 0x00000010,
            InteractionPoint5 = 0x00000020,
            InteractionPoint6 = 0x00000040,
            InteractionPoint7 = 0x00000080,
            InteractionPoint8 = 0x00000100,
            InteractionPoint9 = 0x00000200,
            InteractionPoint10 = 0x00000400,
            InteractionPoint11 = 0x00000800,
            InteractionPoint12 = 0x00001000,
            InteractionPoint13 = 0x00002000,
            InteractionPoint14 = 0x00004000,
            InteractionPoint15 = 0x00008000,
            InteractionPoint16 = 0x00010000,
            InteractionPoint17 = 0x00020000,
            InteractionPoint18 = 0x00040000,
            InteractionPoint19 = 0x00080000,
            InteractionPoint20 = 0x00100000,
            InteractionPoint21 = 0x00200000,
            AllowAwakeSound = 0x00400000,
            EnterWithWeaponDrawn = 0x00800000,
            PlayAnimWhenFull = 0x01000000,
            DisablesActivation = 0x02000000,
            IsPerch = 0x04000000,
            MustExittoTalk = 0x08000000,
            UseStaticAvoidNode = 0x10000000,
            //Unknown29 = 0x20000000,
            HasModel=0x40000000,
            IsSleepFurniture = 0x80000000
        }

        [Flags]
        public enum Entry
        {
            Front = 0x01,
            Behind = 0x02,
            Right = 0x04,
            Left = 0x08,
            Up = 0x10
        }

        [Flags]
        public enum AnimationType
        {
            Sit = 1,
            Lay = 2,
            Lean = 4,
        }
    }

    namespace Internals
    {
        /// <summary>
        /// Parsing for Furniture is fairly custom.  The 2nd flags subrecord has sit booleans, which are combined with both the
        /// 'Markers' list and the 'Marker Entry Points' list from the binary data into one list of objects to be exposed
        /// </summary>
        public partial class FurnitureBinaryCreateTranslation
        {
            public const uint UpperFlagsMask = 0xFF00_0000;
            public const uint NumSits = 25;
            public static readonly RecordType NAM0 = new RecordType("NAM0");
            public static readonly RecordType FNMK = new RecordType("FNMK");
            private static readonly RecordType[] _activeMarkerTypes = new RecordType[]
            {
                new RecordType("ENAM"),
                NAM0,
                FNMK,
            };

            public static partial void FillBinaryFlagsCustom(MutagenFrame frame, IFurnitureInternal item)
            {
                var subFrame = frame.ReadSubrecordFrame();
                // Read flags like normal
                item.Flags = (Furniture.Flag)BinaryPrimitives.ReadUInt16LittleEndian(subFrame.Content);
            }

            public static partial ParseResult FillBinaryFlags2Custom(MutagenFrame frame, IFurnitureInternal item)
            {
                // Clear out old stuff
                // This assumes flags will be parsed first.  Might need to be upgraded to not need that assumption
                item.Markers = null;
                item.Flags = FillBinaryFlags2(frame, (i) => GetNthMarker(item, i), item.Flags);
                return null;
            }


            public static Furniture.Flag FillBinaryFlags2(IMutagenReadStream stream, Func<int, FurnitureMarker> getter, Furniture.Flag? existingFlag)
            {
                var subFrame = stream.ReadSubrecordFrame();
                uint raw = BinaryPrimitives.ReadUInt32LittleEndian(subFrame.Content);

                // Clear out upper bytes of existing flags
                var curFlags = (uint)(existingFlag ?? 0);
                curFlags &= ~UpperFlagsMask;

                // Add in new upper flags
                uint upperFlags = raw & UpperFlagsMask;
                var ret = (Furniture.Flag)(curFlags | upperFlags);

                // Create marker objects for sit flags
                uint markers = raw & 0x00FF_FFFF;
                uint indexToCheck = 1;
                for (int i = 0; i < NumSits; i++)
                {
                    var has = EnumExt.HasFlag(markers, indexToCheck);
                    indexToCheck <<= 1;
                    if (!has) continue;
                    var marker = getter(i);
                    marker.Enabled = true;
                }
                return ret;
            }

            public static FurnitureMarker GetNthMarker(IFurnitureInternal item, int index)
            {
                if (item.Markers == null)
                {
                    item.Markers = new ExtendedList<FurnitureMarker>();
                }
                if (!item.Markers.TryGet(index, out var marker))
                {
                    while (item.Markers.Count <= index)
                    {
                        item.Markers.Add(new FurnitureMarker());
                    }
                    marker = item.Markers[^1];
                }
                return marker;
            }

            public static partial ParseResult FillBinaryDisabledMarkersCustom(MutagenFrame frame, IFurnitureInternal item)
            {
                FillBinaryDisabledMarkers(frame, (i) => GetNthMarker(item, i));
                return null;
            }

            public static void FillBinaryDisabledMarkers(IMutagenReadStream stream, Func<int, FurnitureMarker> getter)
            {
                while (!stream.Complete)
                {
                    // Find next set of records that make up a marker record
                    var next = PluginUtilityTranslation.FindNextSubrecords(
                        stream.RemainingMemory,
                        stream.MetaData.Constants,
                        out var lenParsed,
                        stopOnAlreadyEncounteredRecord: true,
                        recordTypes: _activeMarkerTypes);

                    // Process index first
                    var enamLoc = next[0];
                    if (enamLoc == null)
                    {
                        if (next[1] == null && next[2] == null)
                        {
                            // Other data
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("Could not locate index subrecord of marker data");
                        }
                    }
                    var index = BinaryPrimitives.ReadInt32LittleEndian(stream.MetaData.Constants.SubrecordFrame(stream.RemainingMemory.Slice(enamLoc.Value)).Content);
                    if (index > NumSits)
                    {
                        throw new ArgumentException($"Unexpected index value that was larger than the number of sit slots: {index} > {NumSits}");
                    }

                    var marker = getter(index);

                    // Parse content
                    foreach (var loc in next.Skip(1))
                    {
                        if (loc == null) continue;

                        var subMeta = stream.MetaData.Constants.SubrecordFrame(stream.RemainingMemory.Slice(loc.Value));
                        switch (subMeta.RecordTypeInt)
                        {
                            case 0x304D414E: // NAM0
                                marker.DisabledEntryPoints = new EntryPoints()
                                {
                                    Type = (Furniture.AnimationType)BinaryPrimitives.ReadUInt16LittleEndian(subMeta.Content),
                                    Points = (Furniture.Entry)BinaryPrimitives.ReadUInt16LittleEndian(subMeta.Content.Slice(2)),
                                };
                                break;
                            case 0x4B4D4E46: // FNMK
                                marker.MarkerKeyword.FormKey = FormKeyBinaryTranslation.Instance.Parse(subMeta.Content, stream.MetaData.MasterReferences!);
                                break;
                            default:
                                throw new ArgumentException($"Unexpected record type: {subMeta.RecordType}");
                        }
                    }

                    stream.Position += lenParsed;
                }
            }

            public static partial void FillBinaryMarkersCustom(MutagenFrame frame, IFurnitureInternal item)
            {
                FillBinaryMarkers(frame, (i) => GetNthMarker(item, i));
            }

            public static void FillBinaryMarkers(IMutagenReadStream stream, Func<int, FurnitureMarker> getter)
            {
                var locs = PluginUtilityTranslation.ParseRepeatingSubrecord(
                    stream.RemainingMemory,
                    stream.MetaData.Constants,
                    RecordTypes.FNPR,
                    out var parsed);
                for (int i = 0; i < locs.Length; i++)
                {
                    var marker = getter(i);

                    var loc = locs[i];
                    var subMeta = stream.MetaData.Constants.SubrecordFrame(stream.RemainingMemory.Slice(loc));
                    marker.EntryPoints = new EntryPoints()
                    {
                        Type = (Furniture.AnimationType)BinaryPrimitives.ReadUInt16LittleEndian(subMeta.Content),
                        Points = (Furniture.Entry)BinaryPrimitives.ReadUInt16LittleEndian(subMeta.Content.Slice(2)),
                    };
                }
                stream.Position += parsed;
            }
        }

        public partial class FurnitureBinaryWriteTranslation
        {
            public static partial void WriteBinaryFlagsCustom(MutagenWriter writer, IFurnitureGetter item)
            {
                var flags = (uint)(item.Flags ?? 0);
                // Trim out upper flags
                var normalFlags = flags & ~FurnitureBinaryCreateTranslation.UpperFlagsMask;
                using (HeaderExport.Subrecord(writer, RecordTypes.FNAM))
                {
                    writer.Write(checked((ushort)normalFlags));
                }
            }

            public static partial void WriteBinaryFlags2Custom(MutagenWriter writer, IFurnitureGetter item)
            {
                var flags = (uint)(item.Flags ?? 0);
                // Trim out lower flags
                var exportFlags = flags & FurnitureBinaryCreateTranslation.UpperFlagsMask;

                var markers = item.Markers;
                if (markers != null)
                {
                    // Enable appropriate sit markers
                    uint indexToCheck = 1;
                    foreach (var marker in markers)
                    {
                        exportFlags = EnumExt.SetFlag(exportFlags, indexToCheck, marker.Enabled);
                        indexToCheck <<= 1;
                    }
                }

                // Write out mashup of upper flags and sit markers
                using (HeaderExport.Subrecord(writer, RecordTypes.MNAM))
                {
                    writer.Write(exportFlags);
                }
            }

            public static partial void WriteBinaryDisabledMarkersCustom(MutagenWriter writer, IFurnitureGetter item)
            {
                var markers = item.Markers;
                if (markers == null) return;
                for (int i = 0; i < markers.Count; i++)
                {
                    var marker = markers[i];
                    var disabledPts = marker.DisabledEntryPoints;
                    var markerKeyword = marker.MarkerKeyword;
                    if (disabledPts == null && markerKeyword.FormKeyNullable == null) continue;

                    // Write out index
                    using (HeaderExport.Subrecord(writer, RecordTypes.ENAM))
                    {
                        writer.Write(i);
                    }

                    if (disabledPts != null)
                    {
                        using (HeaderExport.Subrecord(writer, FurnitureBinaryCreateTranslation.NAM0))
                        {
                            writer.Write(checked((ushort)disabledPts.Type));
                            writer.Write(checked((ushort)disabledPts.Points));
                        }
                    }

                    if (markerKeyword.FormKeyNullable != null)
                    {
                        FormKeyBinaryTranslation.Instance.Write(writer, markerKeyword.FormKeyNullable.Value, FurnitureBinaryCreateTranslation.FNMK);
                    }
                }
            }

            public static partial void WriteBinaryMarkersCustom(MutagenWriter writer, IFurnitureGetter item)
            {
                var markers = item.Markers;
                if (markers == null) return;
                // Find last marker that has entry point
                int lastIndex = -1;
                for (int i = 0; i < markers.Count; i++)
                {
                    if (markers[i].EntryPoints != null)
                    {
                        lastIndex = i;
                    }
                }
                if (lastIndex == -1) return;

                // Iterate and export entries up until last not null found
                for (int i = 0; i <= lastIndex; i++)
                {
                    var entryPts = markers[i].EntryPoints;

                    if (entryPts == null)
                    {
                        using (HeaderExport.Subrecord(writer, RecordTypes.FNPR))
                        {
                            writer.Write(checked((uint)Furniture.AnimationType.Sit));
                            writer.WriteZeros(2);
                        }
                    }
                    else
                    {
                        using (HeaderExport.Subrecord(writer, RecordTypes.FNPR))
                        {
                            writer.Write(checked((ushort)entryPts.Type));
                            writer.Write(checked((ushort)entryPts.Points));
                        }
                    }
                }
            }
        }

        public partial class FurnitureBinaryOverlay
        {
            Furniture.Flag? _flags;
            Furniture.Flag? GetFlagsCustom() => _flags;

            private ExtendedList<FurnitureMarker>? _markers;
            public IReadOnlyList<IFurnitureMarkerGetter>? Markers => _markers;

            private FurnitureMarker GetNthMarker(int index)
            {
                if (this._markers == null)
                {
                    this._markers = new ExtendedList<FurnitureMarker>();
                }
                if (!this._markers.TryGet(index, out var marker))
                {
                    while (this._markers.Count <= index)
                    {
                        this._markers.Add(new FurnitureMarker());
                    }
                    marker = this._markers[^1];
                }
                return marker;
            }

            partial void FlagsCustomParse(OverlayStream stream, long finalPos, int offset)
            {
                var subFrame = stream.ReadSubrecordFrame();
                // Read flags like normal
                _flags = (Furniture.Flag)BinaryPrimitives.ReadUInt16LittleEndian(subFrame.Content);
            }

            public partial ParseResult Flags2CustomParse(OverlayStream stream, int offset)
            {
                this._flags = FurnitureBinaryCreateTranslation.FillBinaryFlags2(
                    stream,
                    this.GetNthMarker,
                    this._flags);
                return null;
            }

            public partial ParseResult DisabledMarkersCustomParse(OverlayStream stream, int offset)
            {
                FurnitureBinaryCreateTranslation.FillBinaryDisabledMarkers(
                    stream,
                    this.GetNthMarker);
                return null;
            }

            partial void MarkersCustomParse(OverlayStream stream, long finalPos, int offset, RecordType type, PreviousParse lastParsed)
            {
                FurnitureBinaryCreateTranslation.FillBinaryMarkers(
                    stream,
                    this.GetNthMarker);
            }
        }
    }
}
