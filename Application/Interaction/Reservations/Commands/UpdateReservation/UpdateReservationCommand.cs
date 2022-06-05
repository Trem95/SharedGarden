using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsAcceptedByOwner { get; set; }
    }

    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Reservations.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Reservation), request.Id);
            }
            entity.ReservationDate = request.ReservationDate;
            entity.IsCompleted = request.IsCompleted;
            entity.IsAcceptedByOwner = request.IsAcceptedByOwner;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
