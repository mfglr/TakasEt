using AuthService.Application.Dtos;
using FluentValidation;

namespace AuthService.Application.Validators
{
    internal class SignUpByEmailCommandValidator : AbstractValidator<SignUpByEmailDto> 
    {
        public SignUpByEmailCommandValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email field is required!");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password field is required!");
            RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty().WithMessage("Confirm Password field is required!");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password does not match password confirmation");
        }
    }
}
