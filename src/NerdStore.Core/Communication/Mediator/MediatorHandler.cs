using System.Threading.Tasks;
using MediatR;
using NerdStore.Core.Data.EventSourcing;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.DomainEvents;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.Mediator
{
    /// <summary>
    /// Implementação do MediatR  
    /// </summary>
    public class MediatorHandler : IMediatorHandler
    {
        /*
         * Anotação:
         * O Mediator é baseado em Request e Notificações.
         * 
         * "Quando utilizar o [Send]"
         * Toda vez que eu envio um comando ou seja um "Send"(O Send é sempre um Request), estou querendo dizer que
         * vou realizar alguma ação que irá alterar minha aplicação de alguma forma, (Insert,Update,Delete).
         * 
         * "Quando utilizar o [Publish]"
         * Toda ves que eu Disparo um Evento ou sejá uma "Notificação", é algo que eu quero apenas disparar, não necessariamente 
         * este evento irá alterar algum estado da minha aplicação.
         * 
         * Está divisão é util justamente para representar a nossa intenção, o que realmente queremos fazer.
         */
        private readonly IMediator _mediator;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public MediatorHandler(IMediator mediator, 
                               IEventSourcingRepository eventSourcingRepository)
        {
            _mediator = mediator;
            _eventSourcingRepository = eventSourcingRepository;
        }

        //Dispara o Comando para o Handler Especifico
        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            // Dispara o Comando
            return await _mediator.Send(comando);
        }

        //Dispara a notificação de evento
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            //Publicar Evento
            await _mediator.Publish(evento);
            await _eventSourcingRepository.SalvarEvento(evento);

        }

        //Dispara a notificação de dominio
        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }

        //Dispara o evento de dominio
        public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
        {
            await _mediator.Publish(notificacao);
        }
    }
}