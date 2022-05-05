using System;
using MediatR;

namespace NerdStore.Core.Messages.CommonMessages.DomainEvents
{
    /// <summary>
    /// È uma boa pratica sempre criar uma classe de Domain Event no Core 
    /// para ser possivel compartilhar o Evento entre as outras camadas e projetos
    /// </summary>
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
    }
}