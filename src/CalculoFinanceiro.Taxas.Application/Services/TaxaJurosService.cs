using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Taxas.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Taxas.Application.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        public static readonly double TAXA_JUROS = 0.01;

        public async Task<Status<double>> GetTaxaJuros()
        {
            await Task.CompletedTask;
            return new Status<double>(value: TAXA_JUROS);
        }
    }
}