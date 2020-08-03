using CalculoFinanceiro.Core.Api;
using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Juros.Api.V1.Models;
using CalculoFinanceiro.Juros.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Realiza o cálculo de juros
        /// </summary>
        /// <param name="calculaJurosDTO"><see cref="CalculaJurosDTO"/> com os dados necessários para o cálculo</param>
        /// <response code="200">Resultado do cálculo de juros</response>
        /// <response code="400">Cálculo de juros não realizado</response>
        /// <returns><see cref="Status"/> com o resultado do cálculo</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Status<decimal>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Status<decimal>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculaJuros([FromQuery] CalculaJurosDTO calculaJurosDTO)
        {
            return Status(await _calculoJurosService.CalculaJuros(calculaJurosDTO.ValorInicial.Value, calculaJurosDTO.Meses.Value));
        }
    }
}