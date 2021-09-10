using Microsoft.Extensions.DependencyInjection;
using Service.BoundedContext.AtualizarValorDoAtivo;
using Service.BoundedContext.CadastrarCaritera;
using Service.BoundedContext.NovaCompra;
using Service.UseCase;

namespace Function.Injection
{
    public static class ServiceInjection
    {
        public static void AdicionarCasosDeUso(this IServiceCollection servico)
        {
            servico.AddScoped<ICadastrarCaritera, CadastrarCaritera>();
            servico.AddScoped<INovaCompra, NovaCompra>();
            servico.AddScoped<IAtualizarValorDoAtivo, AtualizarValorDoAtivo>();
        }
    }
}
