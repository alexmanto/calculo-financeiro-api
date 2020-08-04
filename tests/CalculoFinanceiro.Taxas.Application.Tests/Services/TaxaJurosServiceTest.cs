using CalculoFinanceiro.Taxas.Application.Services;
using FluentAssertions;
using Xunit;

namespace CalculoFinanceiro.Taxas.Application.Tests.Services
{
    public class TaxaJurosServiceTest
    {
        public class GetTaxaJuros
        {
            [Fact(DisplayName = "Obter taxa de juros padrão")]
            [Trait("Categoria", "Taxas - TaxaJurosService")]
            public void DeveObterTaxaJurosPadrao()
            {
                // Arrange
                var taxaService = new TaxaJurosService();

                // Act
                var taxa = taxaService.GetTaxaJuros();

                // Assert 
                taxa.Result.Succeeded.Should().BeTrue();
                taxa.Result.Value.Should().Be(TaxaJurosService.TAXA_JUROS);
            }
        }
    }
}