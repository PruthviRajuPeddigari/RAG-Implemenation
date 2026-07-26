public sealed class Document
{
    public string FileName { get; init; } = string.Empty;

    public IReadOnlyList<DocumentPage> Pages { get; init; }
        = [];
}