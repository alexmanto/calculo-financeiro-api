using CalculoFinanceiro.Core.Api.Commons.Extensions;
using CalculoFinanceiro.Core.Api.OpenApi;
using CalculoFinanceiro.Taxas.Api.OpenApi;
using CalculoFinanceiro.Taxas.Application.Services;
using CalculoFinanceiro.Taxas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoFinanceiro.Taxas.Api
{
    public class StartupApiTests
    {
        private static readonly string API_NAME = "Taxas de Juros";

        public StartupApiTests(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IConfigureOpenApiInfo, ConfigureOpenApiInfo>();
            services.RegisterOpenApi(typeof(Startup).Assembly);

            services.AddSingleton<ITaxaJurosService, TaxaJurosService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStatusExceptionHandler();

            app.UseOpenApi(provider, API_NAME);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}