using Application.Common.Interfaces;
using Application.Interaction.Reservations.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Reservations.Queries.GetReservation
{
    public class GetReservationByUserId : IRequest<ReservationsVm>
    {
        public int UserId { get; set; }
    }
    public class GetReservationByUserIdHandler : IRequestHandler<GetReservationByUserId, ReservationsVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetReservationByUserIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationsVm> Handle(GetReservationByUserId request, CancellationToken cancellationToken)
        {
            return new ReservationsVm
            {
                ReservationList = await _context.Reservations
                .ProjectTo<ReservationDTO>(_mapper.ConfigurationProvider)
                .Where(r => (!r.IsDeleted)) //&& !r.Garden.IsDeleted) && (r.ClientId == request.UserId || r.Garden.OwnerId == request.UserId))
                .OrderBy(r => r.Id)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
