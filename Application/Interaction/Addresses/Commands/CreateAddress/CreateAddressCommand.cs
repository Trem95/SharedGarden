using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Addresses.Commands.CreateAddress
{
    public  class CreateAddressCommand : IRequest<int>
    {
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand ,int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = new Address
            {
                Id = 0,
                Country = request.Country,
                PostalCode = request.PostalCode,
                City = request.City,
                Street = request.Street,
                IsDeleted = false
            };
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
