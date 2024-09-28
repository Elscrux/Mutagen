using Mutagen.Bethesda.Plugins.Records;

namespace Mutagen.Bethesda.Plugins.Cache.Internals.Implementations.Internal;

internal sealed class LinkCacheItem : IMajorRecordIdentifierGetter
{
    private readonly IMajorRecordGetter? _record;
    private readonly string? _editorId;

    public FormKey FormKey { get; }
    public string? EditorID => _record?.EditorID ?? _editorId;
    public IMajorRecordGetter Record => _record ?? throw new ArgumentException("Queried for record on a simple cache");

    public LinkCacheItem(
        IMajorRecordGetter? record,
        FormKey formKey,
        string? editorId)
    {
        _record = record;
        _editorId = editorId;
        FormKey = formKey;
    }

    public static LinkCacheItem Factory(IMajorRecordGetter record, bool simple)
    {
        return new LinkCacheItem(
            simple ? null : record,
            record.FormKey,
            simple ? record.EditorID : null);
    }
}