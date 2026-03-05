using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Semantic.Kernel.Example.Console;

public class PerformancePlugin
{
    [KernelFunction, Description("Fornece recomendações sobre alocação de memória em C#")]
    public string GetMemoryOptimizationTip([Description("O tópico sobre performance, ex: 'strings' ou 'LINQ'")] string topic)
    {
        return topic.ToLower() switch
        {
            "strings" => "Evite concatenação de strings em loops. Use StringBuilder para reduzir alocações na Heap.",
            "linq" => "Cuidado com o uso excessivo de LINQ em caminhos críticos (hot paths); ele pode alocar muitos enumeradores.",
            _ => "Sempre utilize Span<T> e Memory<T> para manipular dados de forma eficiente sem alocação extra."
        };
    }
}