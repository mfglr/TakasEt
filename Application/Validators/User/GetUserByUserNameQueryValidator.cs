using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetUserByUserNameQueryValidator : AbstractValidator<GetUserByUserName>
    {
        public GetUserByUserNameQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
