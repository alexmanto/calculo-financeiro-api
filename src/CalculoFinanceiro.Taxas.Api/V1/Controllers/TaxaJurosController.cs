using CalculoFinanceiro.Core.Api;
using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Taxas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Taxas.Api.V1.Controllers
{
    public class TaxaJurosController : ApiBaseController
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <response code="200">Taxa de juros</response>
        /// <response code="400">Taxa de juros não obtida</response>
        /// <returns><see cref="Status"/> com a taxa de juros</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Status<double>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Status<double>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            return Status(await _taxaJurosService.GetTaxaJuros());
        }
    }
}