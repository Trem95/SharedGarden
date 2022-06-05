using Application.Common.Interfaces;
using Application.Interaction.Users.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Users.Queries.GetUser
{
    public class GetAllUsersQuery : IRequest<UsersVm>
    {

    }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UsersVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetAllUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UsersVm> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return new UsersVm
            {
                UserList = await _context.Users
                    .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                    .Where(u => !u.IsDeleted)
                    .OrderBy(u => u.Id)
                    .ToListAsync(cancellationToken)
            };
        }
    }


}
