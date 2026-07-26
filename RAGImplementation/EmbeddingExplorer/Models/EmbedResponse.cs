namespace EmbeddingExplorer.Models;

public class EmbedResponse
{
    public string Model { get; set; } = string.Empty;

    public List<List<float>> Embeddings { get; set; } = [];
}