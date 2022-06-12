using Application.Common.Interfaces;
using Application.Interaction.Users.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Users.Queries.GetUser
{
    public class GetUserByEmailQuery : IRequest<UserDTO>
    {
        public string Email { get; set; }
    }
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetUserByEmailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            UserDTO user = await _context.Users
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .Where(u => u.Email == request.Email)
                .Where(u => !u.IsDeleted)
                .FirstAsync(cancellationToken);
            return user;

        }
    }
}
