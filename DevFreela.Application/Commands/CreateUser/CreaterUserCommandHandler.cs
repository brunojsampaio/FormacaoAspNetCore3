using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Repositories.Transactions;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreaterUserCommandHandler : IRequestHandler<CreaterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IUnitOfWorks _unitOfWorks;

        public CreaterUserCommandHandler(IUserRepository userRepository, IAuthService authService, IUnitOfWorks unitOfWorks)
        {
            _userRepository = userRepository;
            _authService = authService;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<int> Handle(CreaterUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            
            var user = new User(request.FullName,
                request.Email,
                request.BirthDate,
                passwordHash,
                request.Role);

            await _userRepository.AddAsync(user);
            await _unitOfWorks.CommitAsync();

            return user.Id;
        }
    }
}