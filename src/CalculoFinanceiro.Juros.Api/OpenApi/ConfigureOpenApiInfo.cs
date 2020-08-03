using CalculoFinanceiro.Core.Api.OpenApi;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace CalculoFinanceiro.Juros.Api.OpenApi
{
    /// <inheritdoc cref="IConfigureOpenApiInfo"/>
    public class ConfigureOpenApiInfo : IConfigureOpenApiInfo
    {
        /// <inheritdoc />
        public OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, OpenApiContact contact)
        {
            var info = new OpenApiInfo()
            {
                Version = description.ApiVersion.ToString(),
                Title = "Cálculo de Juros",
                Description = "API de Cálculo de Juros",
                Contact = contact
            };

            return info;
        }
    }
}