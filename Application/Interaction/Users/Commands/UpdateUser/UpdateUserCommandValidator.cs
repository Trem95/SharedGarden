using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {

        private readonly IApplicationDbContext _context;
        public UpdateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

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

        public async Task<bool> EmailUnique(UpdateUserCommand model,string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => u.Id != model.Id)
                .AllAsync(u => u.Email != email);
        }

    }
}
