namespace NerdStore.Pagamentos.AntiCorruption
{
    // Está muito semelhante ao mundo real está abstração
    public interface IPayPalGateway
    {
        // 1º Retorna minha chave de servico
        string GetPayPalServiceKey(string apiKey, string encriptionKey);

        // 2º Gera um CardHash atraves de um service key
        string GetCardHashKey(string serviceKey, string cartaoCredito);

        //3 º Realiza o pagamento com a chave deste cartão
        bool CommitTransaction(string cardHashKey, string orderId, decimal amount);
    }
}
