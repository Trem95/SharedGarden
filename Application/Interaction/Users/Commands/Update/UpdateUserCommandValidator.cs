using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {

        private readonly IApplicationDbContext _context;
        public UpdateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email required")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .MustAsync(EmailUnique).WithMessage("Email not available");
        }

        public async Task<bool> EmailUnique(UpdateUserCommand model,string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => u.Id != model.Id)
                .AllAsync(u => u.Email != email);
        }

    }
}
