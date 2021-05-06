using System.Linq;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            
            return user == null ? null : new UserViewModel(user.FullName, user.Email);
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName,
                inputModel.Email,
                inputModel.BirthDate);
            
            _dbContext.Users.Add(user);

            return user.Id;
        }
    }
}