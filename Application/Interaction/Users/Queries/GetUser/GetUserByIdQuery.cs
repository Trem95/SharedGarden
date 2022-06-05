using Application.Common.Interfaces;
using Application.Interaction.Users.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Users.Queries.GetUser
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetUserByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UserDTO user = await _context.Users
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .Where(u => u.Id == request.Id)
                .Where(u => !u.IsDeleted)
                .FirstAsync(cancellationToken);
            return user;

        }
    }
}

