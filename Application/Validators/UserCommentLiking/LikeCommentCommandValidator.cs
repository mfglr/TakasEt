using FluentValidation;
using Models.Dtos;

namespace Application.Validators
{
	public class LikeCommentCommandValidator : AbstractValidator<LikeCommentDto>
	{
        public LikeCommentCommandValidator()
        {
            RuleFor(x => x.CommentId).NotNull().WithMessage("hata");
        }
    }
}
