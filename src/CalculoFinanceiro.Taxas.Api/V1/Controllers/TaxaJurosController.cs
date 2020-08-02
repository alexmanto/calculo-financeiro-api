using CalculoFinanceiro.Core.Api;
using CalculoFinanceiro.Taxas.Application.Services.Interfaces;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _taxaJurosService.GetTaxaJuros());
        }
    }
}