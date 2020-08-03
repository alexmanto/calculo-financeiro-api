using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CalculoFinanceiro.Core.Api.Commons.Extensions
{
    /// <summary>
    /// Extension methods de <see cref="IApplicationBuilder"/>.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Faz com que as exceções da API retornem um BadRequest de <see cref="Status"/>.
        /// </summary>
        /// <param name="applicationBuilder"><see cref="IApplicationBuilder"/> com o pipeline da aplicação.</param>
        public static void UseStatusExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(ConfigureStatusExceptionHandler);
        }

        private static void ConfigureStatusExceptionHandler(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var error = context.Features.Get<IExceptionHandlerFeature>();
                if (error != null)
                {
                    var status = new Status(error.Error.Message);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(status));
                }
            });
        }
    }
}