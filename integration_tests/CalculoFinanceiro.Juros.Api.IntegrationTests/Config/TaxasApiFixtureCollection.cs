using CalculoFinanceiro.Juros.Api;
using Xunit;

namespace CalculoFinanceiro.Utils.IntegrationTests.Config
{
    [CollectionDefinition(nameof(JurosApiFixtureCollection))]
    public class JurosApiFixtureCollection : 
        ICollectionFixture<IntegrationTestsFixture<Juros.Api.StartupApiTests>>,
        ICollectionFixture<IntegrationTestsFixture<Taxas.Api.StartupApiTests>>
    { }
}