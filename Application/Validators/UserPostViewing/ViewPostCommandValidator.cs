using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserPostViewing
{
	public class ViewPostCommandValidator : AbstractValidator<ViewPost>
	{
        public ViewPostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
