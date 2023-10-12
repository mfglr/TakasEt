using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class CreateTokenByUserCommandValidator : AbstractValidator<CreateTokenByUser>
    {
        public CreateTokenByUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("hata");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
