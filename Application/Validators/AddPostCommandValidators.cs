using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class AddPostCommandValidators : AbstractValidator<AddPostRequestDto>
	{
        public AddPostCommandValidators()
        {
			RuleFor(x => x.UserId ).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("hata");
		}
    }
}
