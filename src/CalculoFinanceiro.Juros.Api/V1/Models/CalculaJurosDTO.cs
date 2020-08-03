using Microsoft.AspNetCore.Mvc;
using System;
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
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "O valor do parâmetro valorinicial precisa ser maior que zero.")]
        [FromQuery(Name = "valorinicial")]

        public decimal? ValorInicial { get; set; }

        /// <summary>
        /// Quantidade de meses para aplicar ao cálculo
        /// </summary>
        [Required(ErrorMessage = "O parâmetro meses precisar ser informado.")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor do parâmetro meses precisa ser maior que zero.")]
        [FromQuery(Name = "meses")]
        public int? Meses { get; set; }
    }
}