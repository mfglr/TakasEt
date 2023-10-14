using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserCommentLiking
{
	public class UnlikeCommentValidator : AbstractValidator<UnlikeComment>
	{
        public UnlikeCommentValidator()
        {
            RuleFor(x => x.CommentId).NotNull().WithMessage("hata");
        }
    }
}
