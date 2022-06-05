using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Interaction.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                Id = 0,
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                IsAdmin = request.IsAdmin,
                IsDeleted = false
            };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
