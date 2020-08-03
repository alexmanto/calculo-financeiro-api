using CalculoFinanceiro.Core.Api;
using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Juros.Application.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Api.V1.Controllers
{
    public class ShowMeTheCodeController : ApiBaseController
    {
        private readonly UrlsConfig _urls;

        public ShowMeTheCodeController(IOptions<UrlsConfig> config)
        {
            _urls = config.Value;
        }

        /// <summary>
        /// Retorna a URL do repositório do projeto
        /// </summary>
        /// <response code="200">URL do repositório do projeto</response>
        /// <returns><see cref="Status"/> com a URL do repositório do projeto</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Status<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Ok(_urls.GithubRepository);
        }
    }
}