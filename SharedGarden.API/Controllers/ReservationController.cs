using Application.Interaction.Reservations.Commands.CreateReservation;
using Application.Interaction.Reservations.Commands.UpdateReservation;
using Application.Interaction.Reservations.Commands.DeleteReservation;
using Application.Interaction.Reservations.Queries.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Interaction.Reservations.Queries.GetReservation;

namespace SharedGarden.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ReservationsVm>> Get()
        {
            return await Mediator.Send(new GetAllReservationsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> Get(int id)
        {
            return await Mediator.Send(new GetReservationByIdQuery{ Id = id });
        }

        [HttpGet("UserId/{id}")]
        public async Task<ActionResult<ReservationsVm>> GetReservationsByUserId(int id)
        {
            return await Mediator.Send(new GetReservationByUserId { UserId = id });
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateReservationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateReservationCommand command)
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
            await Mediator.Send(new DeleteReservationCommand { Id = id });

            return NoContent();
        }
    }
}
