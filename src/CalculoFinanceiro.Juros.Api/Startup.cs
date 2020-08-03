using CalculoFinanceiro.Core.Api.Commons.Extensions;
using CalculoFinanceiro.Core.Api.OpenApi;
using CalculoFinanceiro.Core.Infrastructure.Filters;
using CalculoFinanceiro.Juros.Api.Extensions;
using CalculoFinanceiro.Juros.Api.OpenApi;
using CalculoFinanceiro.Juros.Application.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoFinanceiro.Juros.Api
{
    public class Startup
    {
        private static readonly string API_NAME = "Cálculo de Juros";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<UrlsConfig>(Configuration.GetSection("urls"));

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateFilter));

            });

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            services.AddSingleton<IConfigureOpenApiInfo, ConfigureOpenApiInfo>();
            services.RegisterOpenApi(typeof(Startup).Assembly);

            services.RegisterServices();
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