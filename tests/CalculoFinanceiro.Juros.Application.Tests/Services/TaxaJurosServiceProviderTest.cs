using CalculoFinanceiro.Juros.Application.Config;
using CalculoFinanceiro.Juros.Application.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using System.Net;
using Xunit;

namespace CalculoFinanceiro.Juros.Application.Tests.Services
{
    public class TaxaJurosServiceProviderTest
    {
        private IOptions<UrlsConfig> _optionsUrlsConfig;

        public TaxaJurosServiceProviderTest()
        {
            var urlsConfig = new UrlsConfig();
            urlsConfig.Taxas = "http://localhost:8200/api";
            _optionsUrlsConfig = Options.Create<UrlsConfig>(urlsConfig);
        }

        public class GetTaxaJuros : TaxaJurosServiceProviderTest
        {
            [Fact(DisplayName = "Validar status de falha quando URL de Taxas não for registrada")]
            [Trait("Categoria", "Juros - TaxaJurosServiceProvider")]
            public async void DeveObterStatusDeFalhaQuandoUrlDeTaxasForNula()
            {
                // Arrange
                var options = Options.Create<UrlsConfig>(new UrlsConfig());
                var taxaJurosProvider = new TaxaJurosServiceProvider(options, MockHttpClient.GetMocked(HttpStatusCode.OK));

                // Act
                var taxa = await taxaJurosProvider.GetTaxaJuros();

                // Assert 
                taxa.Succeeded.Should().BeFalse();
                taxa.Value.Should().Be(0);
                taxa.ErrorMessage.Should().NotBeNull();
            }

            [Theory(DisplayName = "Validar status de falha quando obter falha ao executar request no serviço de taxas")]
            [Trait("Categoria", "Juros - TaxaJurosServiceProvider")]
            [InlineData(HttpStatusCode.BadRequest)]
            [InlineData(HttpStatusCode.NotFound)]
            [InlineData(HttpStatusCode.InternalServerError)]
            [InlineData(HttpStatusCode.Unauthorized)]
            [InlineData(HttpStatusCode.Forbidden)]
            public async void DeveObterStatusDeFalhaQuandoTentarExecutarRequest(HttpStatusCode statusCode)
            {
                // Arrange
                var taxaJurosProvider = new TaxaJurosServiceProvider(_optionsUrlsConfig, MockHttpClient.GetMocked(statusCode));

                // Act
                var taxa = await taxaJurosProvider.GetTaxaJuros();

                // Assert 
                taxa.Succeeded.Should().BeFalse();
                taxa.Value.Should().Be(0);
                taxa.ErrorMessage.Should().NotBeNull();
            }

            [Fact(DisplayName = "Obter resultado de sucesso ao consultar serviço de taxa de juros")]
            [Trait("Categoria", "Juros - CalculoJurosService")]
            public async void DeveObterValorDaTaxaDeJuros()
            {
                // Arrange
                var taxaJurosProvider = new TaxaJurosServiceProvider(_optionsUrlsConfig, MockHttpClient.GetMocked(HttpStatusCode.OK));

                // Act
                var taxa = await taxaJurosProvider.GetTaxaJuros();

                // Assert 
                taxa.Succeeded.Should().BeTrue();
                taxa.Value.Should().Be(0.01);
                taxa.ErrorMessage.Should().BeNull();
            }
        }
    }
}