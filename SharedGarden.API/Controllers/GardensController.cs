using Application.Interaction.Gardens.Commands.CreateGarden;
using Application.Interaction.Gardens.Commands.UpdateGarden;
using Application.Interaction.Gardens.Commands.DeleteGarden;
using Application.Interaction.Gardens.Queries.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Interaction.Gardens.Queries.GetGarden;
using Microsoft.AspNetCore.Authorization;

namespace SharedGarden.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardensController : ApiController
    {
        [HttpGet]
        [Authorize("read:messages")]
        public async Task<ActionResult<GardensVm>> Get()
        {
            return await Mediator.Send(new GetAllGardensQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GardenDTO>> Get(int id)
        {
            return await Mediator.Send(new GetGardenByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGardenCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateGardenCommand command)
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
            await Mediator.Send(new DeleteGardenCommand { Id = id });

            return NoContent();
        }
    }
}
