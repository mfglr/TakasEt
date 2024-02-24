using AuthService.Application.Dtos;
using FluentValidation;

namespace AuthService.Application.Validators
{
    public class RemoveBlockCommandValidator : AbstractValidator<RemoveBlockDto>
    {
        public RemoveBlockCommandValidator()
        {
            RuleFor(x => x.BlockedId).NotEmpty().NotNull().WithMessage("Blocked id is required!");
        }
    }
}
