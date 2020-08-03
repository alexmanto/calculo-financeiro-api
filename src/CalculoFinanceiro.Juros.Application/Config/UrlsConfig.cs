namespace CalculoFinanceiro.Juros.Application.Config
{
    /// <summary>
    /// Configuração das URLs da camada de comunicação do serviço
    /// </summary>
    public class UrlsConfig
    {
        /// <summary>
        /// URLs relacionadas a comunicação com o serviço de Taxas
        /// </summary>
        public class TaxasOperations
        {
            /// <summary>
            /// Método responsável por retornar a rota do endpoint de busca da taxa de juros
            /// </summary>
            /// <returns></returns>
            public static string GetTaxaJuros() => $"/V1/taxajuros";
        }

        /// <summary>
        /// URL do serviço de taxas
        /// </summary>
        public string Taxas { get; set; }

        /// <summary>
        /// URL do repositório do projeto
        /// </summary>
        public string GithubRepository { get; set; }
    }
}