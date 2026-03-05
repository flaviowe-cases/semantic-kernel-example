using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder();

// Conectando ao Ollama rodando no Docker
builder.AddOpenAIChatCompletion(
    modelId: "qwen2.5:0.5b",
    apiKey: "ignored", // Ollama local não precisa de API Key real
    endpoint: new Uri("http://localhost:11434/v1")
);

var kernel = builder.Build();

// Primeiro prompt de teste
Console.WriteLine("Enviando prompt para o modelo...");
var response = await kernel.InvokePromptAsync("Explique o conceito de 'Memory Management' em .NET em uma frase.");

Console.WriteLine($"Resposta: {response}");