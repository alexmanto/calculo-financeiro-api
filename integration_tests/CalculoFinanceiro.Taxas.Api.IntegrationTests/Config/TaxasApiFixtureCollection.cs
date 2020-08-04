using CalculoFinanceiro.Taxas.Api;
using Xunit;

namespace CalculoFinanceiro.Utils.IntegrationTests.Config
{
    [CollectionDefinition(nameof(TaxasApiFixtureCollection))]
    public class TaxasApiFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>> { }
}