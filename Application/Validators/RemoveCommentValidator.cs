using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class RemoveCommentValidator : AbstractValidator<RemoveCommentRequestDto>
	{
        public RemoveCommentValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("hata");
        }
    }
}
