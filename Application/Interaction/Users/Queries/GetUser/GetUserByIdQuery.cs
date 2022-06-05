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

namespace Application.Interaction.Users.Queries.GetUser
{
    public class GetUserByIdQuery : IRequest<UsersVm>
    {
        public int Id { get; set; }
    }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UsersVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetUserByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsersVm> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return new UsersVm
            {
                UserList = await _context.Users
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .Where(u => u.Id == request.Id).ToListAsync(cancellationToken)
            };
        }
    }
}

