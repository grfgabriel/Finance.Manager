using Function.Injection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Function.Startup))]
namespace Function
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AdicionarRepositorio();
            builder.Services.AdicionarCasosDeUso();

        }
    }
}
