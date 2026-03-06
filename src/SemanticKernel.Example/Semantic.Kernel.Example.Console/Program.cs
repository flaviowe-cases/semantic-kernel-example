using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Semantic.Kernel.Example.Console;

var builder = Kernel.CreateBuilder();

builder.Services.AddLogging(configure => configure.AddConsole());
builder.Services.AddSingleton<IFunctionInvocationFilter, CustomFunctionFilter>();

// Conectando ao Ollama rodando no Docker
builder.AddOpenAIChatCompletion(
    modelId: "qwen2.5:0.5b",
    apiKey: "ignored", // Ollama local não precisa de API Key real
    endpoint: new Uri("http://localhost:11434/v1")
);

var kernel = builder.Build();

// Importando o plugin
kernel.ImportPluginFromType<TodoPlugin>();
kernel.ImportPluginFromType<GetCepPlugin>();

// 2. Configura a execução para permitir que a IA chame ferramentas
OpenAIPromptExecutionSettings settings = new() 
{ 
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions 
};

do
{
    Console.Write("voce diz -> ");
    var message = Console.ReadLine();
    
    if  (string.IsNullOrEmpty(message))
        continue;
    
    if (message == "exit")
        break;
    
    var response = await  kernel.InvokePromptAsync(message, new KernelArguments(settings));
    
    Console.Write("ollama diz -> ");
    Console.WriteLine(response);
     
} while (true); 
