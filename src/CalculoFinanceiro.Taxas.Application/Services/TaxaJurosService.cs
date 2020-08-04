using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Taxas.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Taxas.Application.Services
{
    /// <inheritdoc cref="ITaxaJurosService">
    public class TaxaJurosService : ITaxaJurosService
    {
        public static readonly double TAXA_JUROS = 0.01;

        /// <inheritdoc/>
        public async Task<Status<double>> GetTaxaJuros()
        {
            await Task.CompletedTask;
            return new Status<double>(TAXA_JUROS);
        }
    }
}