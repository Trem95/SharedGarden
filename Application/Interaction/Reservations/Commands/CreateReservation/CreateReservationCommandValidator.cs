using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateReservationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(r => r.ReservationDate)
                .NotEmpty().WithMessage("Reservation date is required.");

        }

        


    }
}
