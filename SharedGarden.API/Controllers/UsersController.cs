using Application.Interaction.Users.Commands.CreateUser;
using Application.Interaction.Users.Commands.UpdateUser;
using Application.Interaction.Users.Commands.DeleteUser;
using Application.Interaction.Users.Queries.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Interaction.Users.Queries.GetUser;

namespace SharedGarden.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<UsersVm>> Get()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            return await Mediator.Send(new GetUserByIdQuery { Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}
