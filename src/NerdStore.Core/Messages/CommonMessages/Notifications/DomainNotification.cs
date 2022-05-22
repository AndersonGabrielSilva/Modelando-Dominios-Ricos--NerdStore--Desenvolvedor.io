using System;
using MediatR;

namespace NerdStore.Core.Messages.CommonMessages.Notifications
{
    /// <summary>
    /// É uma classe expecifica para realizar as notificações de dominio
    /// <para>É semelhante a Classe de Event, porêm desejamos deixar ela mais expecifica para 
    /// as notificações de dominio.</para>
    /// <para></para>
    /// </summary>
    public class DomainNotification : Message, INotification
    {
        public DateTime Timestamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            Timestamp = DateTime.Now;
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}