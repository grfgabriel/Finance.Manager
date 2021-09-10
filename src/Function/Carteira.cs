using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Service.BoundedContext.CadastrarCaritera;
using System.Text.Json;

namespace Function
{
    public class Carteira
    {

        public Carteira(ICadastrarCaritera cadastrarCaritera, ILogger<Carteira> logger)
        {
            _cadastrarCaritera = cadastrarCaritera;
            _logger = logger;
        }
        private readonly ILogger<Carteira> _logger;
        private readonly ICadastrarCaritera _cadastrarCaritera;

        [FunctionName("CadastrarCaritera")]
        public async Task<IActionResult> CadastrarCaritera(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            CadastrarCariteraInput input;
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                var requestBody = await streamReader.ReadToEndAsync();
                input = JsonSerializer.Deserialize<CadastrarCariteraInput>(requestBody);
            }
            await _cadastrarCaritera.Handle(input);

            return new OkResult();
        }
    }
}
