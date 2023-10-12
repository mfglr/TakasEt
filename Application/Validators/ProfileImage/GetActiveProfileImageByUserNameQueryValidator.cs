using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetActiveProfileImageByUserNameQueryValidator : AbstractValidator<GetActiveProfileImageByUserName>
	{
        public GetActiveProfileImageByUserNameQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
