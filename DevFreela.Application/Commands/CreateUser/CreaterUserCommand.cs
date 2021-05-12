using System;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreaterUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}