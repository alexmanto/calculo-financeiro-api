using CalculoFinanceiro.Core.Api.Commons;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Application.Services.Interfaces
{
    public interface ITaxaJurosServiceProvider
    {
        Task<Status<double>> GetTaxaJuros();
    }
}