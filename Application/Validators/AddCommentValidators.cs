using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class AddCommentValidators : AbstractValidator<AddCommentRequestDto>
	{
        public AddCommentValidators()
        {
			RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage("hata");
		}
    }
}
