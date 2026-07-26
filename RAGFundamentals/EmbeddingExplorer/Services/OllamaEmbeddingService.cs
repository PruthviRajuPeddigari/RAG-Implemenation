using EmbeddingExplorer.Configuration;
using EmbeddingExplorer.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace EmbeddingExplorer.Services;

public class OllamaEmbeddingService
{
    private readonly HttpClient _httpClient;
    private readonly OllamaOptions _options;

    public OllamaEmbeddingService(
        HttpClient httpClient,
        IOptions<OllamaOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<float[]> GenerateEmbeddingAsync(string text)
    {
        var request = new EmbedRequest
        {
            Model = _options.EmbeddingModel,
            Input = text
        };

        var response = await _httpClient.PostAsJsonAsync(
            "/api/embed",
            request);

        response.EnsureSuccessStatusCode();

        var embedResponse =
            await response.Content.ReadFromJsonAsync<EmbedResponse>();

        if (embedResponse is null ||
            embedResponse.Embeddings.Count == 0)
        {
            throw new InvalidOperationException(
                "No embedding was returned by Ollama.");
        }

        return [.. embedResponse.Embeddings[0]];
    }
}