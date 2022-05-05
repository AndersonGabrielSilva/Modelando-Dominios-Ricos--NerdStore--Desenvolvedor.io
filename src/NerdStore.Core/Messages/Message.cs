using System;

namespace NerdStore.Core.Messages
{
    /// <summary>
    /// Classe base abstrata, responsavel por saber qual é o Tipo da mensagem
    /// e o AggregateId (Entidade)
    /// <para>O Evento é uma mensagem, o Commando é uma mensagem e etc </para>
    /// </summary>
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            // Retorna o Nome da Classe que está implementando a Message
            MessageType = GetType().Name;
        }
    }
}