using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Juros.Application.Config;
using CalculoFinanceiro.Juros.Application.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Application.Services
{
    /// <inheritdoc cref="ITaxaJurosServiceProvider">
    public class TaxaJurosServiceProvider : ITaxaJurosServiceProvider
    {
        private readonly HttpClient _httpClient;
        private readonly UrlsConfig _urls;

        public TaxaJurosServiceProvider(IOptions<UrlsConfig> config, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _urls = config.Value;
        }

        ///<inheritdoc/>
        public async Task<Status<double>> GetTaxaJuros()
        {
            Status<double> status;
            try
            {
                var content = await CallService();
                status = JsonConvert.DeserializeObject<Status<double>>(content);
            }
            catch (Exception e)
            {
                return new Status<double>($"Não foi possível realizar a consulta da taxa de juros. {e.Message}");
            }

            return new Status<double>(status.Value);
        }

        private async Task<string> CallService()
        {
            if (string.IsNullOrEmpty(_urls.Taxas))
                throw new NullReferenceException("O serviço de taxas de juros não possui uma URL registrada.");

            var uri = _urls.Taxas + UrlsConfig.TaxasOperations.GetTaxaJuros();

            var result = await _httpClient.GetAsync(uri);
            if (!result.IsSuccessStatusCode)
                throw new HttpRequestException($"Código de falha: {result.StatusCode}");

            return await result.Content.ReadAsStringAsync();
        }
    }
}
