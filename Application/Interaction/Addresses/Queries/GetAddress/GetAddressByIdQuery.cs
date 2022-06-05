using Application.Common.Interfaces;
using Application.Interaction.Addresses.Queries.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Addresses.Queries.GetAddress
{
    public class GetAddressByIdQuery : IRequest<AddressDTO>
    {
        public int Id { get; set; }
    }

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAddressByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddressDTO> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            AddressDTO address = new AddressDTO();
            try
            {
                address = await _context.Addresses
               .ProjectTo<AddressDTO>(_mapper.ConfigurationProvider)
               .Where(a => a.Id == request.Id)
               .Where(a => !a.IsDeleted)
               .FirstAsync(cancellationToken);

                return address;
            }
            catch (Exception ex)
            {
                Console.WriteLine(address);
                throw;
            }
        }
    }
}
