using CalculoFinanceiro.Core.Api;
using CalculoFinanceiro.Juros.Api.V1.Models;
using CalculoFinanceiro.Juros.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Api.V1.Controllers
{
    public class CalculaJurosController : ApiBaseController
    {
        private ICalculoJurosService _calculoJurosService;

        public CalculaJurosController(ICalculoJurosService calculoJurosService)
        {
            _calculoJurosService = calculoJurosService;
        }

        [HttpGet]
        public async Task<IActionResult> CalculaJuros([FromQuery] CalculaJurosDTO calculaJurosDTO)
        {
            return Ok(await _calculoJurosService.CalculaJuros(calculaJurosDTO.ValorInicial, calculaJurosDTO.Meses));
        }
    }
}