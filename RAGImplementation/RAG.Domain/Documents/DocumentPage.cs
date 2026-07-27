namespace RAG.Domain.Documents;

public sealed class DocumentPage
{
    public int PageNumber { get; init; }

    public string Text { get; init; } = string.Empty;
}