using Application.Common.Interfaces;
using Application.Interaction.Gardens.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Gardens.Queries.GetGarden
{
    public class GetGardensByUserIdQuery : IRequest<GardensVm>
    {
        public int UserID { get; set; }
    }

    public class GetGardensByUserIdQueryHandler : IRequestHandler<GetGardensByUserIdQuery, GardensVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetGardensByUserIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GardensVm> Handle(GetGardensByUserIdQuery request, CancellationToken cancellationToken)
        {
            return new GardensVm
            {
                GardenList = await _context.Gardens
                .ProjectTo<GardenDTO>(_mapper.ConfigurationProvider)
                .Where(g => !g.IsDeleted && g.OwnerId == request.UserID)
                .OrderBy(g => g.Id)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
