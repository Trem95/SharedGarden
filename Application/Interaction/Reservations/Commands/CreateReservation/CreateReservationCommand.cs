using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<int>
    {
        public int GardenId { get; set; }
        public int ClientId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsAcceptedByOwner { get; set; }
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Reservation
            {
                Id = 0,
                GardenId = request.GardenId,
                ClientId = request.ClientId,
                ReservationDate = request.ReservationDate,
                IsCompleted = false,
                IsAcceptedByOwner = false,
            };
            _context.Reservations.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }
    }
}
