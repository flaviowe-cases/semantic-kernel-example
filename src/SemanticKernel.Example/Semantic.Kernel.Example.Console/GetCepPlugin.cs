using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Semantic.Kernel.Example.Console;

public class GetCepPlugin
{
    [KernelFunction, Description("Busca o endereço a partir de um cep")]
    public async Task<string> GetCep([Description("cep para busca")]string cep)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://viacep.com.br");

        var response = await httpClient.GetAsync($"ws/{cep}/json/")
            .ConfigureAwait(false);
        
        var address = await response.Content.ReadAsStringAsync();
        return address;
    }
}