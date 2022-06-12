using Application.Interaction.Addresses.Commands.CreateAddress;
using Application.Interaction.Addresses.Commands.UpdateAddress;
using Application.Interaction.Addresses.Commands.DeleteAddress;
using Application.Interaction.Addresses.Queries.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Interaction.Addresses.Queries.GetAddress;
using Microsoft.AspNetCore.Authorization;

namespace SharedGarden.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ApiController
    {
        [HttpGet]
        [Authorize("read:messages")]
        public async Task<ActionResult<AddressesVm>> Get()
        {
            return await Mediator.Send(new GetAllAddressesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> Get(int id)
        {
            return await Mediator.Send(new GetAddressByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAddressCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAddressCommand command)
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
            await Mediator.Send(new DeleteAddressCommand { Id = id });

            return NoContent();
        }
    }
}
