﻿using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class AddProfileImageCommandValidator : AbstractValidator<AddUserImageDto>
    {
        public AddProfileImageCommandValidator()
        {
            RuleFor(x => x.Stream).NotEmpty().NotNull().WithMessage("hata");
            RuleFor(x => x.Extention).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
