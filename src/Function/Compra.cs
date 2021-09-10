using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Service.BoundedContext.NovaCompra;
using System.Text.Json;

namespace Function
{
    public class Compra
    {
        private readonly ILogger<Compra> _logger;
        private readonly INovaCompra _novaCompra;

        public Compra(ILogger<Compra> logger, INovaCompra novaCompra)
        {
            _logger = logger;
            _novaCompra = novaCompra;
        }

        [FunctionName("NovaCompra")]
        public async Task<IActionResult> NovaCompra(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            NovaCompraInput input;
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                var requestBody = await streamReader.ReadToEndAsync();
                input = JsonSerializer.Deserialize<NovaCompraInput>(requestBody);
            }
            await _novaCompra.Handle(input);

            return new OkResult();
        }
    }
}
