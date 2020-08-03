using CalculoFinanceiro.Juros.Application.Services;
using CalculoFinanceiro.Juros.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoFinanceiro.Juros.Api.Extensions
{
    /// <summary>
    /// Classe de extenção, referente a DI dos serviços utilizados no projeto
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Método responsável por fazer os registros dos serviços
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ICalculoJurosService, CalculoJurosService>();
            services.AddHttpClient<ITaxaJurosServiceProvider, TaxaJurosServiceProvider>();
        }
    }
}