using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetUserByUserNameQueryValidator : AbstractValidator<GetUserByUserNameRequestDto>
	{
        public GetUserByUserNameQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
