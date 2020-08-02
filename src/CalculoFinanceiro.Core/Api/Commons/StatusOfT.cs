using System;

namespace CalculoFinanceiro.Core.Api.Commons
{
    /// <summary>
    /// Representa um <see cref="Status"/>
    /// </summary>
    /// <typeparam name="T">Tipo de valor que será mantido pela operação.</typeparam>
    public class Status<T> : Status
    {
        public Status() : base()
        { }

        public Status(T value)
        {
            Value = value;
        }

        public Status(string errorMessage)
            : base(errorMessage)
        { }

        public Status(Exception exception)
            : base(exception)
        { }

        /// <summary>
        /// Valor obtido pela operação
        /// </summary>
        public T Value { get; set; }
    }
}