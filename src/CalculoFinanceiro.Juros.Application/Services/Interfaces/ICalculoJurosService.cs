using CalculoFinanceiro.Core.Api.Commons;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Application.Services.Interfaces
{
    /// <summary>
    /// Responsável pelos serviços referente ao cálculo de juros
    /// </summary>
    public interface ICalculoJurosService
    {
        /// <summary>
        /// Método responsável por fazer o cálculo de juros
        /// </summary>
        /// <param name="valorBase">Valor para a base de cálculo</param>
        /// <param name="meses">Quantidade de meses a serem aplicados no cálculo</param>
        /// <returns><see cref="Status"/> com o resultado do cálculo</returns>
        Task<Status<decimal>> CalculaJuros(decimal valorBase, int meses);
    }
}