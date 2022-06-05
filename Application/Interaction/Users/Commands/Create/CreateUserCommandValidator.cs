
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Users.Commands.Create
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

        }

        public async Task<bool> EmailUnique(string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AllAsync(u => u.Email != email,cancellationToken);
        }

    }
}
