namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
    /// <summary>
    /// Evento de Integração são os eventos que são responsaveis por fazer a ponte de um contexto
    /// para outro contexto
    /// <para></para>
    /// </summary>
    public abstract class IntegrationEvent : Event
    {
        /*
         * Por Exemplo:
         * -Estou no contexto de venda finalizando um carrinho de compras e durante este precesso
         *  eu precise debitar a quantidade de estoque.
         *  
         * -Porém esta responsabilidade está no contexto de Catalogo, ou será para eu poder realizar a baixa de estoque
         *  eu disparo um evento de integração que será capturado pelo contexto de catalogo
         *  para realizar a baixa de estoque.
         *  
         * -Desta forma não precisamos referenciar um projeto dentro de outro projeto.
         * 
         *
         */

    }
}