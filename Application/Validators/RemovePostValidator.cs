using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class RemovePostValidator : AbstractValidator<RemovePostRequestDto>
	{
        public RemovePostValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
