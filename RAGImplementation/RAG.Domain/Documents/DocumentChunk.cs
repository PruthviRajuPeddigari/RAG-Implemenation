public sealed class DocumentChunk
{
    public Guid ChunkId { get; init; }

    public Guid DocumentId { get; init; }

    public int ChunkIndex { get; init; }

    public int StartPage { get; init; }

    public int EndPage { get; init; }

    public string Text { get; init; } = string.Empty;

    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}