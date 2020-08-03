using CalculoFinanceiro.Core.Api.Commons;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Taxas.Application.Services.Interfaces
{
    /// <summary>
    /// Responsável pelos serviços referente a taxa de juros
    /// </summary>
    public interface ITaxaJurosService
    {
        /// <summary>
        /// Método responsável por fazer a busca da taxa de juros
        /// </summary>
        /// <returns><see cref="Status"/> com o resultado da busca</returns>
        Task<Status<double>> GetTaxaJuros();
    }
}