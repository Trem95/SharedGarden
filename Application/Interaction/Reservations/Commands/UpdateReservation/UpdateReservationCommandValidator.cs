using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateReservationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(r => r.ReservationDate)
                .NotEmpty().WithMessage("Reservation date is required.");
                

        }
    }
}
