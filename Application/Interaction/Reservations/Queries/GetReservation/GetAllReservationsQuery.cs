using Application.Common.Interfaces;
using Application.Interaction.Reservations.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Reservations.Queries.GetReservation
{
    public class GetAllReservationsQuery : IRequest<ReservationsVm>
    {

    }

    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery,ReservationsVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetAllReservationsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationsVm> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            return new ReservationsVm
            {
                ReservationList = await _context.Reservations
                .ProjectTo<ReservationDTO>(_mapper.ConfigurationProvider)
                .Where(r => !r.IsDeleted)
                .OrderBy(r => r.Id)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
