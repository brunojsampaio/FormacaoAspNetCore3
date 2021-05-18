using System.Threading.Tasks;

namespace DevFreela.Core.Repositories.Transactions
{
    public interface IUnitOfWorks
    {
        Task CommitAsync();
        void Rollback();
    }
}