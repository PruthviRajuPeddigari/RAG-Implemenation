using EmbeddingExplorer.Configuration;
using EmbeddingExplorer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Bind configuration
builder.Services.Configure<OllamaOptions>(
    builder.Configuration.GetSection("Ollama"));

// Register HttpClient
builder.Services.AddHttpClient();

// Register service
builder.Services.AddHttpClient<OllamaEmbeddingService>((serviceProvider, client) =>
{
    var options = serviceProvider
        .GetRequiredService<Microsoft.Extensions.Options.IOptions<OllamaOptions>>()
        .Value;

    client.BaseAddress = new Uri(options.BaseUrl);

    client.Timeout = TimeSpan.FromMinutes(5);
});

var host = builder.Build();

// Resolve the service
var embeddingService =
    host.Services.GetRequiredService<OllamaEmbeddingService>();

Console.WriteLine("Application started...");

var text = "How many casual leaves are allowed?";

var embedding =
    await embeddingService.GenerateEmbeddingAsync(text);

Console.WriteLine($"Dimensions : {embedding.Length}");

Console.WriteLine();

Console.WriteLine("First 10 values:");

foreach (var value in embedding.Take(10))
{
    Console.WriteLine(value);
}

Console.ReadLine();