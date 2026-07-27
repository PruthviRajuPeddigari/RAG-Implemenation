namespace RAG.Domain.Documents;

public sealed class Document
{
    public string FileName { get; init; } = string.Empty;

    public IReadOnlyList<DocumentPage> Pages { get; init; } = [];

    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    public int PageCount => Pages.Count;
}