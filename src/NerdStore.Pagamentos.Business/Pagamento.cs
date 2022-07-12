using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Pagamentos.Business
{
    /*
     * Pagamento : É o desejo do nosso cliente de realizar um pagamento,
     * ou seja ele quer/quis realizar um pagamento
     * 
     * Transação : É a transação de fato, é o retorno do nosso gatway de pagamentos,
     * ou seja se possui este registro significa que de fato o pagamento foi realizado
     */
    public class Pagamento : Entity, IAggregateRoot
    {
        public Guid PedidoId { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }

        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        // EF. Rel.
        public Transacao Transacao { get; set; }
    }
}
