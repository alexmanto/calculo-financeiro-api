using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Juros.Application.Services;
using CalculoFinanceiro.Juros.Application.Services.Interfaces;
using CalculoFinanceiro.Taxas.Application.Services;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalculoFinanceiro.Juros.Application.Tests.Services
{
    public class CalculoJurosServiceTest
    {
        private AutoMocker _mocker;
        private CalculoJurosService _jurosService;

        public CalculoJurosServiceTest()
        {
            _mocker = new AutoMocker();
            _jurosService = _mocker.CreateInstance<CalculoJurosService>();
        }

        public class CalculaJuros : CalculoJurosServiceTest
        {
            [Theory(DisplayName = "Validar parâmetros com valores inválidos")]
            [Trait("Categoria", "Juros - CalculoJurosService")]
            [InlineData(0, 1)]
            [InlineData(1, 0)]
            [InlineData(-1, 1)]
            [InlineData(1, -1)]
            public void DeveObterStatusDeFalhaQuandoUtilizarParametrosInvalidos(decimal valorBase, int meses)
            {
                // Arrange
                // Act
                var juros = _jurosService.CalculaJuros(valorBase, meses);

                // Assert 
                juros.Result.Succeeded.Should().BeFalse();
                juros.Result.Value.Should().Be(0);
                juros.Result.ErrorMessage.Should().NotBeNull();
            }

            [Fact(DisplayName = "Validar falha ao chamar TaxaJurosServiceProvider")]
            [Trait("Categoria", "Juros - CalculoJurosService")]
            public void DeveObterStatusDeFalhaQuandoChamarTaxaJurosServiceProvider()
            {
                // Arrange
                _mocker.GetMock<ITaxaJurosServiceProvider>().Setup(r => r.GetTaxaJuros()).Returns(Task.FromResult(new Status<double>("Falha")));

                // Act
                var juros = _jurosService.CalculaJuros(1, 1);

                // Assert 
                juros.Result.Succeeded.Should().BeFalse();
                juros.Result.Value.Should().Be(0);
                juros.Result.ErrorMessage.Should().Equals("Falha");
                _mocker.GetMock<ITaxaJurosServiceProvider>().Verify(r => r.GetTaxaJuros(), Times.Once);
            }

            [Theory(DisplayName = "Validar cálculo de juros")]
            [Trait("Categoria", "Juros - CalculoJurosService")]
            [InlineData(100, 1, 101)]
            [InlineData(100, 8, 108.28)]
            [InlineData(360000, 12, 405657.01)]
            [InlineData(1, 170, 5.42)]
            [InlineData(13.2787, 49, 21.62)]
            [InlineData(0.37, 75, 0.78)]
            public void DeveRealizarCalculoComSucesso(decimal valorBase, int meses, decimal resultado)
            {
                // Arrange
                _mocker.GetMock<ITaxaJurosServiceProvider>().Setup(r => r.GetTaxaJuros()).Returns(Task.FromResult(new Status<double>(TaxaJurosService.TAXA_JUROS)));

                // Act
                var juros = _jurosService.CalculaJuros(valorBase, meses);

                // Assert 
                juros.Result.Succeeded.Should().BeTrue();
                juros.Result.Value.Should().Be(resultado);
                juros.Result.ErrorMessage.Should().BeNull();
                _mocker.GetMock<ITaxaJurosServiceProvider>().Verify(r => r.GetTaxaJuros(), Times.Once);
            }

            [Theory(DisplayName = "Validar tratamento de falha ao realizar o cálculo inválido")]
            [Trait("Categoria", "Juros - CalculoJurosService")]
            [InlineData("1000000000000000000000000000", 1)]
            [InlineData("1", 1000000000)]
            public void DeveObterStatusDeFalhaQuandoTentarRealizarCalculoInvalido(string valorBase, int meses)
            {
                // Arrange
                _mocker.GetMock<ITaxaJurosServiceProvider>().Setup(r => r.GetTaxaJuros()).Returns(Task.FromResult(new Status<double>(TaxaJurosService.TAXA_JUROS)));

                // Act
                var juros = _jurosService.CalculaJuros(Convert.ToDecimal(valorBase), meses);

                // Assert 
                juros.Result.Succeeded.Should().BeFalse();
                juros.Result.Value.Should().Be(0);
                juros.Result.ErrorMessage.Should().NotBeNull();
                _mocker.GetMock<ITaxaJurosServiceProvider>().Verify(r => r.GetTaxaJuros(), Times.Once);
            }
        }
    }
}