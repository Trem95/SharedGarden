using Application.Common.Interfaces;
using Application.Interaction.Users.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UsersVm>
    {

    }
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UsersVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return new UsersVm
            {
                UserList = await _context.Users
                    .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                    .OrderBy(u => u.Id)
                    .ToListAsync(cancellationToken)
            };

            return null;
        }
    }


}
