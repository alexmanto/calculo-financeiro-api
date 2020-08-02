using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoFinanceiro.Juros.Application.Config
{
    public class UrlsConfig
    {
        public class TaxasOperations
        {
            public static string GetTaxaJuros() => $"/V1/taxajuros";
        }

        public string Taxas { get; set; }
    }
}
