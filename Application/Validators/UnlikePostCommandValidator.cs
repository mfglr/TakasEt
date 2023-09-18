using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class UnlikePostCommandValidator : AbstractValidator<UnlikePostRequestDto>
	{
        public UnlikePostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
