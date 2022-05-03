using System;

namespace NerdStore.Core.DomainObjects
{
    /// <summary>
    /// É uma boa pratica especializar a Exception.
    /// <para>Informando que é uma Exceção de Dominio</para>
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException()
        { }

        public DomainException(string message) : base(message)
        { }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}