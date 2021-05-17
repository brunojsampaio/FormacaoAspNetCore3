using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            
            var user = await _mediator.Send(query);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreaterUserCommand command)
        {
            var id = await _mediator.Send(command);

            command.Password = "";
            
            return CreatedAtAction(nameof(GetById), new {id = id}, command);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
            {
                return BadRequest();
            }
            
            return Ok(loginUserViewModel);
        }
    }
}