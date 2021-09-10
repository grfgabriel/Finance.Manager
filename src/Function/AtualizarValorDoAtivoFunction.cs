using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Service.BoundedContext.AtualizarValorDoAtivo;
using System.Text.Json;

namespace Function
{
    public class AtualizarValorDoAtivoFunction
    {
        private readonly ILogger<AtualizarValorDoAtivoFunction> _logger;
        private readonly IAtualizarValorDoAtivo _atualizarValorDoAtivo;

        public AtualizarValorDoAtivoFunction(ILogger<AtualizarValorDoAtivoFunction> logger, IAtualizarValorDoAtivo atualizarValorDoAtivo)
        {
            _logger = logger;
            _atualizarValorDoAtivo = atualizarValorDoAtivo;
        }

        [FunctionName("AtualizarValorDoAtivo")]
        public async Task<IActionResult> AtualizarValorDoAtivo(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            AtualizarValorDoAtivoInput input;
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                var requestBody = await streamReader.ReadToEndAsync();
                input = JsonSerializer.Deserialize<AtualizarValorDoAtivoInput>(requestBody);
            }
            await _atualizarValorDoAtivo.Handle(input);

            return new OkResult();
        }
    }
}
