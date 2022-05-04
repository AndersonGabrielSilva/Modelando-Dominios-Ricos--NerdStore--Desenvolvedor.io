using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    //É uma boa pratica chipar para receber apenas entidades do tipo AggregateRoot
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        /// <summary>
        /// UnitOfWork
        /// <para>Padrão utilizado para evitar utilizar o roolback</para>
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}