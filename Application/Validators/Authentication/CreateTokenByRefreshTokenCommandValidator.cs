using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class CreateTokenByRefreshTokenCommandValidator : AbstractValidator<RefreshTokenDto>
    {
        public CreateTokenByRefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotNull().NotEmpty().WithMessage("hata");
        }
    }
}
