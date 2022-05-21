using System;
using MediatR;

namespace NerdStore.Core.Messages
{
    /// <summary>
    /// Responsavel por saber qual o horario que este evento/Message foi lançado
    /// <para>[INotification] - MediatR - É Responsavel para trabalhar com Eventos no meu Dominio</para>
    /// </summary>
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}