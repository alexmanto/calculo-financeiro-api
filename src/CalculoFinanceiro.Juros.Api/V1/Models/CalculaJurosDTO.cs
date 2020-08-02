using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CalculoFinanceiro.Juros.Api.V1.Models
{
    /// <summary>
    /// DTO que representa a entrada de informações para o cálculo de juros
    /// </summary>
    public class CalculaJurosDTO
    {
        /// <summary>
        /// Valor base para o cálculo 
        /// </summary>
        [Required(ErrorMessage = "O parâmetro valorinicial precisar ser informado.")]
        [FromQuery(Name = "valorinicial")]

        public decimal ValorInicial { get; set; }

        /// <summary>
        /// Quantidade de meses para aplicar ao cálculo
        /// </summary>
        [Required(ErrorMessage = "O parâmetro meses precisar ser informado.")]
        [FromQuery(Name = "meses")]
        public int Meses { get; set; }
    }
}
