using System.Threading.Tasks;
using DevFreela.Core.Repositories.Transactions;

namespace DevFreela.Infrastructure.Persistence.Repositories.Transactions
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly DevFreelaDbContext _dbContext;

        public UnitOfWorks(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            //
        }
    }
}