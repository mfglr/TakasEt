using AuthService.Application.Dtos;
using FluentValidation;

namespace AuthService.Application.Validators
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailDto>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("User id is required!");
            RuleFor(x => x.Token).NotNull().NotEmpty().WithMessage("Token is required!");
        }
    }
}
