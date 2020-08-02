﻿using CalculoFinanceiro.Core.Api.Commons;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Taxas.Application.Services.Interfaces
{
    public interface ITaxaJurosService
    {
        Task<Status<double>> GetTaxaJuros();
    }
}