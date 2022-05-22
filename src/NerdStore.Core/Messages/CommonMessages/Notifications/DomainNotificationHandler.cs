using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NerdStore.Core.Messages.CommonMessages.Notifications
{
    /// <summary>
    /// Irá ser responsavel por implementar o Domain Notification    
    /// </summary>
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        /*
         * A Ideia é Criar uma lista de Notificações, e toda vez que lá no dominio eu desejar notificacar o cliente de alguma 
         * informação ou mensagem de erro, eu dispare uma notificação que será capturada pelo handler e enviada posteriormente
         * para o Client
         * 
         */
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            //Recebe a Notificação e adiciona na lista
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        //Obtem as Notificações
        public virtual List<DomainNotification> ObterNotificacoes()
        {
            return _notifications;
        }

        //Verificia se possui notificação
        public virtual bool TemNotificacao()
        {
            return ObterNotificacoes().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}