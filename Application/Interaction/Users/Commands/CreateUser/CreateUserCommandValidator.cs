using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(u => u.Email)
                .MaximumLength(75).WithMessage("Max 75 characters.")
                .NotEmpty().WithMessage("Email is required.")
                .MustAsync(EmailUnique)
                .WithMessage("The specified email already exists.");

            RuleFor(u => u.Name)
                .MaximumLength(75).WithMessage("Max 75 characters.")
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(u => u.LastName)
                .MaximumLength(75).WithMessage("Max 75 characters.")
                .NotEmpty().WithMessage("Last name is required.");


        }

        public async Task<bool> EmailUnique(string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AllAsync(u => u.Email != email, cancellationToken);
        }

    }
}
