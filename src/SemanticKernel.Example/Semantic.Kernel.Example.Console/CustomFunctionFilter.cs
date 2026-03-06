using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

namespace Semantic.Kernel.Example.Console;

public class CustomFunctionFilter(ILogger<CustomFunctionFilter> logger) : IFunctionInvocationFilter
{
    public async Task OnFunctionInvocationAsync(FunctionInvocationContext context, Func<FunctionInvocationContext, Task> next)
    {
        logger.LogInformation("Iniciando funcionamento de tarefa");
        
        // Continua a execução da função
        await next(context);
        
        logger.LogInformation("Finalizando funcionamento de tarefa");
    }
}