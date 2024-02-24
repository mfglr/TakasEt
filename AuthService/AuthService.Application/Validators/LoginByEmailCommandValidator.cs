using AuthService.Application.Dtos;
using FluentValidation;

namespace AuthService.Application.Validators
{
    public class LoginByEmailCommandValidator : AbstractValidator<LoginByEmailDto>
    {
        public LoginByEmailCommandValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required!");

        }
    }
}
