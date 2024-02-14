using AuthService.Api.Dtos;
using FluentValidation;

namespace AuthService.Api.Validators
{
    public class SignUpByEmailCommandValidator : AbstractValidator<SignUpByEmailDto> 
    {
        public SignUpByEmailCommandValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("UserName field is required!");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email field is required!");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password field is required!");
        }
    }
}
