using System.Threading.Tasks;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.DomainEvents;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.Mediator
{

    public interface IMediatorHandler
    {
        /// <summary>
        /// Dispara o Evento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="evento"></param>
        /// <returns></returns>
        Task PublicarEvento<T>(T evento) where T : Event;
        
        /// <summary>
        /// Envia o Command / Dispara o Command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comando"></param>
        /// <returns></returns>
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}