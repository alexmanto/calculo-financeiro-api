using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Utils.IntegrationTests.Config;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CalculoFinanceiro.Juros.Api.IntegrationTests.Controllers
{
    [Collection(nameof(JurosApiFixtureCollection))]
    public class ShowMeTheCodeControllerTest
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _fixture;

        public ShowMeTheCodeControllerTest(IntegrationTestsFixture<StartupApiTests> fixture)
        {
            _fixture = fixture;
        }

        public class Get : ShowMeTheCodeControllerTest
        {
            public Get(IntegrationTestsFixture<StartupApiTests> fixture) : base(fixture) { }

            [Fact(DisplayName = "Obter URL do repositório Git do projeto")]
            [Trait("Categoria", "Integração API Juros - ShowMeTheCodeController")]
            public async Task DeveObterUrlRepositorioGit()
            {
                // Arrange
                // Act
                var response = await _fixture.Client.GetAsync("api/V1/ShowMeTheCode");

                // Assert
                response.IsSuccessStatusCode.Should().BeTrue();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var status = JsonConvert.DeserializeObject<Status<string>>(response.Content.ReadAsStringAsync().Result);
                status.Succeeded.Should().BeTrue();
                status.Value.Should().NotBeNull();
            }
        }
    }
}