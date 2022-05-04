using System.Threading.Tasks;

namespace NerdStore.Core.Data
{
    /// <summary>
    /// Interface que representa o Commit ou melhor "SaveChanges()"
    /// </summary>
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}