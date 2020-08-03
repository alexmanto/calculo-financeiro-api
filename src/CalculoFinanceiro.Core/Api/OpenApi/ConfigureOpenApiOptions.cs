using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace CalculoFinanceiro.Core.Api.OpenApi
{
    /// <summary>
    /// Define os documentos que serão criados pelo Swagger, com base nas versões disponíveis na API
    /// </summary>
    public class ConfigureOpenApiOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IConfigureOpenApiInfo _openApiInfo;
        private readonly OpenApiContact _openApiContact;

        public ConfigureOpenApiOptions(IApiVersionDescriptionProvider provider, IConfigureOpenApiInfo openApiInfo)
        {
            _provider = provider ?? throw new ArgumentNullException($"O parâmetro {nameof(provider)} está nulo, registre AddVersionedApiExplorer no service collection."); ;
            _openApiInfo = openApiInfo ?? throw new ArgumentNullException($"o parâmetro {nameof(openApiInfo)} está nulo, registre IConfigureOpenApiInfo no container."); ;
            _openApiContact = new OpenApiContact() { Name = "Alex Sandro Manto", Email = "alex-manto@hotmail.com" };
        }

        ///<inheritdoc/>
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, GetOpenApiInfo(description));
            }
        }

        private OpenApiInfo GetOpenApiInfo(ApiVersionDescription description)
        {
            var info = _openApiInfo.CreateInfoForApiVersion(description, _openApiContact);

            if (description.IsDeprecated)
                info.Description += " - This version is deprecated.";

            return info;
        }
    }
}