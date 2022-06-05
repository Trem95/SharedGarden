using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            entity.Name = request.Name;
            entity.LastName= request.LastName;
            entity.Email = request.Email;
            entity.IsAdmin = request.IsAdmin;
            entity.IsDeleted = request.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
