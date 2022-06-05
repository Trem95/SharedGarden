using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string City { get;set; }
        public string Street { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Addresses.FindAsync(request.Id);
                if (entity != null)
                {
                    throw new NotFoundException(nameof(Address), request.Id);
                }

                entity.Country = request.Country;
                entity.PostalCode = request.PostalCode;
                entity.City = request.City;
                entity.Street = request.Street;
                entity.IsDeleted = request.IsDeleted;
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Unit.Value;
        }
    }
}
