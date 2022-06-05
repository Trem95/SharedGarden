﻿using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateAddressCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(a => a.City)
                .MaximumLength(250).WithMessage("Max 250 characters.")
                .NotEmpty().WithMessage("City is required.");
            
            RuleFor(a => a.Country)
                .MaximumLength(250).WithMessage("Max 250 characters.")
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(a => a.Street)
                .MaximumLength(250).WithMessage("Max 250 characters.")
                .NotEmpty().WithMessage("Street is required.");

            RuleFor(a => a.PostalCode)
                .MaximumLength(20).WithMessage("Max 20 characters.")
                .NotEmpty().WithMessage("Postal code is required.");
        }
    }
}
