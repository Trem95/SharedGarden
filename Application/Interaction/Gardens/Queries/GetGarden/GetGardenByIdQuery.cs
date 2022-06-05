using Application.Common.Interfaces;
using Application.Interaction.Gardens.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Gardens.Queries.GetGarden
{
    public  class GetGardenByIdQuery : IRequest<GardenDTO>
    {
        public int Id { get; set; }
    }

    public class GetGardenByIdQueryHandler : IRequestHandler<GetGardenByIdQuery, GardenDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetGardenByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GardenDTO> Handle(GetGardenByIdQuery request, CancellationToken cancellationToken)
        {
            GardenDTO garden = await _context.Gardens
                .ProjectTo<GardenDTO>(_mapper.ConfigurationProvider)
                .Where(g => g.Id == request.Id)
                .Where(g => !g.IsDeleted)
                .FirstAsync(cancellationToken);
            return garden;
        }
    }
}
