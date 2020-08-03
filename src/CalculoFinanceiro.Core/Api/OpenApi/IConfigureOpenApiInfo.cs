using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace CalculoFinanceiro.Core.Api.OpenApi
{
    /// <summary>
    /// Interface para configuração dp OpenApiInfo
    /// </summary>
    public interface IConfigureOpenApiInfo
    {
        /// <summary>
        /// Método responsável por criar e retornar as informações de cabeçalho da página do OpenApi
        /// </summary>
        /// <param name="description"><see cref="ApiVersionDescription"/></param>
        /// <param name="description"><see cref="OpenApiContact"/></param>
        /// <returns><see cref="OpenApiInfo"/></returns>
        OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, OpenApiContact contact);
    }
}