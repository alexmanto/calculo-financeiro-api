using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Juros.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Application.Services
{
    /// <inheritdoc cref="ICalculoJurosService"/>
    public class CalculoJurosService : ICalculoJurosService
    {
        ITaxaJurosServiceProvider _taxaJurosServiceProvider;

        public CalculoJurosService(ITaxaJurosServiceProvider taxaJurosServiceProvider)
        {
            _taxaJurosServiceProvider = taxaJurosServiceProvider;
        }

        /// <inheritdoc cref="ICalculoJurosService.CalculaJuros(decimal, int)"/>
        public async Task<Status<decimal>> CalculaJuros(decimal valorBase, int meses)
        {
            if (valorBase <= 0) 
                return new Status<decimal>($"O parâmetro {nameof(valorBase)} deve possuir valor maior que zero.");

            if (meses <= 0) 
                return new Status<decimal>($"O parâmetro {nameof(meses)} deve possuir valor maior que zero.");

            var taxaJuros = await _taxaJurosServiceProvider.GetTaxaJuros();
            if (!taxaJuros) 
                return new Status<decimal>(taxaJuros.ErrorMessage);

            try
            {
                var resultado = RealizaCalculo(taxaJuros.Value, valorBase, meses);
                return new Status<decimal>(resultado);
            }
            catch (ArithmeticException e)
            {
                return new Status<decimal>($"Não foi possível realizar o cálculo de juros: {e.Message}");
            }
        }

        private decimal RealizaCalculo(double taxaJuros, decimal valorBase, int meses)
        {
            var percentualJuros = (decimal)Math.Pow(1 + taxaJuros, meses);
            return Math.Truncate(valorBase * percentualJuros * 100) / 100;
        }
    }
}