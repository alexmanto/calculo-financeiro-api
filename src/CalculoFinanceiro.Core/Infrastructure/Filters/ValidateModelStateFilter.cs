using CalculoFinanceiro.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace CalculoFinanceiro.Core.Infrastructure.Filters
{
    /// <summary>
    /// Filter responsável por validar o ModelState
    /// </summary>
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Método responsável por validar o ModelState e retornar um BadRequest, caso esteja inválido
        /// </summary>
        /// <param name="context">Contexto em execução</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            var validationErrors = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage)
                .ToArray();

            var resultErrorMessage = string.Join(Environment.NewLine, validationErrors);

            context.Result = new BadRequestObjectResult(new Status(resultErrorMessage));
        }
    }
}