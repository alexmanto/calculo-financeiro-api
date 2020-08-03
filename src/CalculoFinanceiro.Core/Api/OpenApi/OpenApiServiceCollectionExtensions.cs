using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CalculoFinanceiro.Core.Api.OpenApi
{
    /// <summary>
    /// Classe de extenção do <see cref="IServiceCollection"/>, para o registro do OpenApi(Swagger) no container
    /// </summary>
    public static class OpenApiServiceCollectionExtensions
    {
        /// <summary>
        /// Registra as configurações do Swagger no container
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/> da aplicação</param>
        /// <param name="assembly"><see cref="Assembly"/> que registrará a documentação a partir de comentários de código</param>
        public static void RegisterOpenApi(this IServiceCollection services, Assembly assembly)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureOpenApiOptions>();

            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                    options.IncludeXmlComments(xmlPath);
            });
        }
    }
}