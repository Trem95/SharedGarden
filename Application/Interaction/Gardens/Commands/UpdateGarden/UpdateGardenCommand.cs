using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Gardens.Commands.UpdateGarden
{
    public class UpdateGardenCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fire { get; set; }
        public string Shelter { get; set; }
        public bool IsDeleted { get; set; }
        public int Price { get; set; }
    }

    public class UpdateGardenCommandHandler : IRequestHandler<UpdateGardenCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateGardenCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateGardenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Gardens.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Garden), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Fire = (request.Fire != null && request.Fire != string.Empty) ? request.Fire : "-";
            entity.Shelter = (request.Shelter != null && request.Shelter != string.Empty) ? request.Shelter : "-";
            entity.IsDeleted = request.IsDeleted;
            entity.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
