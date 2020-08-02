using CalculoFinanceiro.Core.Api;
using CalculoFinanceiro.Taxas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(_taxaJurosService.GetTaxaJuros());
        }
    }
}