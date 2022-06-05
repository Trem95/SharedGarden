
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Interaction.Gardens.Commands.CreateGarden
{
    public class CreateGardenCommandsValidator : AbstractValidator<CreateGardenCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateGardenCommandsValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(g => g.Name)
               .MaximumLength(50).WithMessage("Max 50 characters.")
               .NotEmpty().WithMessage("Name is required.");

            RuleFor(g => g.Description)
               .MaximumLength(250).WithMessage("Max 250 characters.")
               .NotEmpty().WithMessage("Description is required.");

            RuleFor(g => g.Price)
               .NotEmpty().WithMessage("Price is required.")
            .Must(PriceIsValid).WithMessage("Price has to be superior to 0.");
        }

        public bool PriceIsValid(int price)
        {
            return price > 0;
        }
    }
}
