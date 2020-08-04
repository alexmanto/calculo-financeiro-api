using CalculoFinanceiro.Utils.IntegrationTests.Config;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CalculoFinanceiro.Juros.Api.IntegrationTests.Controllers
{
    [Collection(nameof(JurosApiFixtureCollection))]
    public class CalculaJurosControllerTest
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _fixture;

        public CalculaJurosControllerTest(IntegrationTestsFixture<StartupApiTests> fixture)
        {
            _fixture = fixture;
        }

        public class CalculaJuros : CalculaJurosControllerTest
        {
            public CalculaJuros(IntegrationTestsFixture<StartupApiTests> fixture) : base(fixture) { }

            [Fact(DisplayName = "Obter URL do repositório Git do projeto")]
            [Trait("Categoria", "Integração API Juros - CalculaJurosController")]
            public async Task DeveObterUrlRepositorioGit()
            {
                // Arrange
                var query = new Dictionary<string, string>
                {
                    ["valorinicial"] = "100",
                    ["meses"] = "10"
                };
                var uri = QueryHelpers.AddQueryString("/api/V1/CalculaJuros", query);

                // Act
                var response = await _fixture.Client.GetAsync(uri);

                // Assert
                //response.IsSuccessStatusCode.Should().BeTrue();
                //response.StatusCode.Should().Be(HttpStatusCode.OK);

                //var status = JsonConvert.DeserializeObject<Status<string>>(response.Content.ReadAsStringAsync().Result);
                //status.Succeeded.Should().BeTrue();
                //status.Value.Should().NotBeNull();
            }
        }
    }
}