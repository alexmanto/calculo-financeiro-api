using CalculoFinanceiro.Core.Api.Commons;
using CalculoFinanceiro.Taxas.Application.Services;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Juros.Application.Tests.Services
{
    public class MockHttpClient
    {
        public static HttpClient GetMocked(HttpStatusCode httpStatusCode)
        {
            var taxaPadrao = JsonConvert.SerializeObject(new Status<double>(TaxaJurosService.TAXA_JUROS));
            var contentResponse = (httpStatusCode.Equals(HttpStatusCode.OK)) ? taxaPadrao : "0";

            var mock = new Mock<HttpMessageHandler>();
            mock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = httpStatusCode,
                    Content = new StringContent(contentResponse)
                });

            return new HttpClient(mock.Object);
        }
    }
}