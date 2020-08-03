using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace CalculoFinanceiro.Core.Api.OpenApi
{
    /// <summary>
    /// Classe de extenção do <see cref="IApplicationBuilder"/>, para a utilização do OpenApi(Swagger)
    /// </summary>
    public static class OpenApiApplicationBuilderExtensions
    {
        private static readonly string BASE_PATH = "api/docs";

        /// <summary>
        /// Extension methods de <see cref="IApplicationBuilder"/>, para fazer uso do OpenApi
        /// A documentação ficará disponível na rota ~/api/docs
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        /// <param name="provider"><see cref="IApiVersionDescriptionProvider"/>, sendo necessário fazer o registro de AddVersionedApiExplorer no ServiceCollection</param>
        /// <param name="apiName">Nome da Api</param>
        /// <returns><see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, IApiVersionDescriptionProvider provider, string apiName)
        {
            if (provider == null)
                throw new ArgumentNullException($"O parâmetro {nameof(provider)} está nulo, registre AddVersionedApiExplorer no service collection.");

            if (string.IsNullOrEmpty(apiName))
                throw new ArgumentNullException($"O parâmetro {nameof(apiName)} está nulo, informe um valor para o nome da API.");

            app.UseSwagger(options =>
            {
                options.RouteTemplate = BASE_PATH + "/{documentName}/doc.json";
            });
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = apiName;
                options.EnableFilter();
                options.DocExpansion(DocExpansion.List);
                options.RoutePrefix = BASE_PATH;
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/{BASE_PATH}/{description.GroupName}/doc.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}