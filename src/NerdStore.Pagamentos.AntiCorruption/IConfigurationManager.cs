namespace NerdStore.Pagamentos.AntiCorruption
{
    // Simula uma classe que irá obter os dados de configuração
    public interface IConfigurationManager
    {
        string GetValue(string node);
    }
}