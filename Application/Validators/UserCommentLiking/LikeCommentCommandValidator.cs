﻿using Application.Dtos;
using FluentValidation;

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
