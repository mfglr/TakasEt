using Application.Dtos;
using Application.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators
{
    public class SignUpCommandValidator : AbstractValidator<SignUpRequestDto>
	{

        public SignUpCommandValidator(UserManager<User> userManager)
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("You have to specify a username!");
			RuleFor(x => x.Password).NotEmpty().WithMessage("The {PropertyName} can't be empty!");
            RuleFor(x => x.PasswordConfirmation).NotEmpty().WithMessage("The field can't be empty!");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("The field can't be empty!");
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirmation).WithMessage("Password field and PasswordConfirmation field does not match!");
            RuleFor(x => x)
                .MustAsync(async (root, command, context, cancellationToken) =>
                {

                    var anyUserByUserName = await userManager.Users.AnyAsync(x => x.UserName == command.UserName);
                    if (anyUserByUserName)
                    {
                        context.MessageFormatter.AppendArgument("message", "The {PropertyName} you specified is already defined!");
                        return false;
                    }

                    var anyUserByEmail = await userManager.Users.AnyAsync(x => x.Email == command.Email);
                    if (anyUserByEmail)
                    {
                        context.MessageFormatter.AppendArgument("message", "The {PropertyName} you specified is already defined!");
                        return false;
                    }

                    return true;
                });
        }

    }
}
