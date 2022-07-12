namespace NerdStore.Pagamentos.Business
{
    // Na camada de negocio há somente a interface a implementação de fato fica na camada de anticorrupção
    public interface IPagamentoCartaoCreditoFacade
    {
        Transacao RealizarPagamento(Pedido pedido, Pagamento pagamento);
    }
}