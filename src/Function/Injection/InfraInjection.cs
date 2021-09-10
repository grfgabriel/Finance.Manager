using Domain.Data.Interface;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Function.Injection
{
    public static class InfraInjection
    {
        public static void AdicionarRepositorio(this IServiceCollection servico)
        {
            servico.AddScoped<ICarteiraRepository, CarteiraRepository>();
        }
    }
}
