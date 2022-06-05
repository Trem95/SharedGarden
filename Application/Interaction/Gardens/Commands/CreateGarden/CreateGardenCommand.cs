using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Gardens.Commands.CreateGarden
{
    public class CreateGardenCommand : IRequest<int>
    {
        public int OwnerId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fire { get; set; }
        public string Shelter { get; set; }
        public bool IsDeleted { get; set; }
        public int Price { get; set; }
    }

    public class CreateGardenCommandHandler : IRequestHandler<CreateGardenCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateGardenCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGardenCommand request, CancellationToken cancellationToken)
        {
            var entity = new Garden
            {
                Id = 0,
                OwnerId = request.OwnerId,
                AddressId = request.AddressId,
                Name = request.Name,
                Description = request.Description,
                Fire = (request.Fire != null && request.Fire != string.Empty) ? request.Fire : "-",
                Shelter = (request.Shelter != null && request.Shelter != string.Empty) ? request.Shelter : "-",
                IsDeleted = false,
                Price = request.Price
            };
            _context.Gardens.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
