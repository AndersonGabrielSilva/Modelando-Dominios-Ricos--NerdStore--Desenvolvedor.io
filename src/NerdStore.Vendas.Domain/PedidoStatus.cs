namespace NerdStore.Vendas.Domain
{
    /// <summary>
    /// Irá auxiliar a acompanhar o status do Pedido
    /// </summary>
    public enum PedidoStatus
    {
        Rascunho = 0,
        Iniciado = 1,
        Pago = 4,
        Entregue = 5,
        Cancelado = 6
    }
}