using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Semantic.Kernel.Example.Console;

public class TodoPlugin
{
    private readonly List<string> _tasks = [];
    
    [KernelFunction, Description("Adiciona uma nova tarefa à lista de afazeres")]
    public string AddTask([Description("O nome da tarefa")] string task)
    {
        _tasks.Add(task);
        return $"Tarefa '{task}' adicionada com sucesso. Total de tarefas: {_tasks.Count}";
    }

    [KernelFunction, Description("Lista todas as tarefas pendentes")]
    public string GetTasks()
    {
        if (_tasks.Count == 0) return "Nenhuma tarefa pendente.";
        return "Tarefas: " + string.Join(", ", _tasks);
    }
}