using Application.Common.Interfaces;
using Application.Interaction.Addresses.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Addresses.Queries.GetAddress
{
    public class GetAllAddressesQuery : IRequest<AddressesVm>
    {
    }
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery,AddressesVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllAddressesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddressesVm> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            return new AddressesVm
            {
                AddressList = await _context.Addresses
                .ProjectTo<AddressDTO>(_mapper.ConfigurationProvider)
                .Where(a => !a.IsDeleted)
                .OrderBy(a => a.Id)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
