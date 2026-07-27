using RAG.Domain.Documents;

namespace RAG.Domain.Embeddings;

public sealed class EmbeddedChunk
{
    public required DocumentChunk Chunk { get; init; }

    public ReadOnlyMemory<float> Embedding { get; init; }
}