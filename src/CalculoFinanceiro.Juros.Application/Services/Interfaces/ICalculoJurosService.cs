using CalculoFinanceiro.Core.Api.Commons;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Application.Services.Interfaces
{
    public interface ICalculoJurosService
    {
        Task<Status<decimal>> CalculaJuros(decimal valorBase, int meses);
    }
}