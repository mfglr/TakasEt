﻿using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginDto>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("hata");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
