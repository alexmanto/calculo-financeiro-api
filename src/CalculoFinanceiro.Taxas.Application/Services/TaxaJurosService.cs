using CalculoFinanceiro.Taxas.Application.Services.Interfaces;

namespace CalculoFinanceiro.Taxas.Application.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        public static readonly double TAXA_JUROS = 0.01;

        public double GetTaxaJuros() => TAXA_JUROS;
    }
}