using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder();

// Conectando ao Ollama rodando no Docker
builder.AddOpenAIChatCompletion(
    modelId: "qwen2.5:0.5b",
    apiKey: "ignored", // Ollama local não precisa de API Key real
    endpoint: new Uri("http://localhost:11434/v1")
);

var kernel = builder.Build();

do
{
    Console.Write("voce diz -> ");
    var message = Console.ReadLine();
    
    if  (string.IsNullOrEmpty(message))
        continue;
    
    if (message == "exit")
        break;
    
    var response = await  kernel.InvokePromptAsync(message);
    
    Console.Write("ollama diz -> ");
    Console.WriteLine(response);
     
} while (true); 
