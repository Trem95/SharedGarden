using Application.Common.Interfaces;
using Application.Interaction.Reservations.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Reservations.Queries.GetReservation
{
    public class GetReservationByIdQuery : IRequest<ReservationDTO>
    {
        public int Id { get;set; }
    }
    
    public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdQuery, ReservationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetReservationByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationDTO> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            ReservationDTO reservation = await _context.Reservations
                .ProjectTo<ReservationDTO>(_mapper.ConfigurationProvider)
                .Where(r => r.Id == request.Id)
                .Where(r => !r.IsDeleted)
                .FirstAsync(cancellationToken);
            return reservation;
        }
    }

}
