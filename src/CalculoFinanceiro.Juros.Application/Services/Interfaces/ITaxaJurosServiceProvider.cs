using CalculoFinanceiro.Core.Api.Commons;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Application.Services.Interfaces
{
    /// <summary>
    /// Responsável por prover a taxa de juros
    /// </summary>
    public interface ITaxaJurosServiceProvider
    {
        /// <summary>
        /// Método responsável por fazer a busca da taxa de juros
        /// </summary>
        /// <returns><see cref="Status"/> com o resultado da busca</returns>
        Task<Status<double>> GetTaxaJuros();
    }
}