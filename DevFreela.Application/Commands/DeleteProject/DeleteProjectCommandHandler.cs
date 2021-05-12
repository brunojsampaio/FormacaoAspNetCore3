using System.Threading;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public DeleteProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);
            
            project.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}