﻿using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetFirstImageOfPostsByUserIdQueryValidator : AbstractValidator<GetFirstImageOfPostsByUserIdRequestDto>
	{
        public GetFirstImageOfPostsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
