using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetPostsByUserNameQueryValidator : AbstractValidator<GetPostsByUserName>
	{
        public GetPostsByUserNameQueryValidator()
        {
			RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("hata");
		}

	}
}
