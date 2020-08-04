using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Taxas.Application.Services;
using CalculoFinanceiro.Utils.IntegrationTests.Config;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CalculoFinanceiro.Taxas.Api.IntegrationTests.V1.Controllers
{
    [Collection(nameof(TaxasApiFixtureCollection))]
    public class TaxaJurosControllerTest
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _fixture;

        public TaxaJurosControllerTest(IntegrationTestsFixture<StartupApiTests> fixture)
        {
            _fixture = fixture;
        }

        public class Get : TaxaJurosControllerTest
        {
            public Get(IntegrationTestsFixture<StartupApiTests> fixture) : base(fixture) { }

            [Fact(DisplayName = "Obter taxa de juros padrão")]
            [Trait("Categoria", "Integração API Taxas - TaxaJurosController")]
            public async Task DeveObterTaxaJurosPadrao()
            {
                // Arrange
                // Act
                var response = await _fixture.Client.GetAsync("api/V1/TaxaJuros");

                // Assert
                response.IsSuccessStatusCode.Should().BeTrue();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var status = JsonConvert.DeserializeObject<Status<double>>(response.Content.ReadAsStringAsync().Result);
                status.Succeeded.Should().BeTrue();
                status.Value.Should().Be(TaxaJurosService.TAXA_JUROS);
            }
        }
    }
}