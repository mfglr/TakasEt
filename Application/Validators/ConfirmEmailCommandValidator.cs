using Application.Dtos.ConfirmEmail;
using Application.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommandRequestDto>
    {
        public ConfirmEmailCommandValidator(UserManager<User> userManager)
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required for email confirmation!");
			RuleFor(x => x.EmailConfirmationToken).NotEmpty().WithMessage("Token is required for email confirmation!");

			RuleFor(x => x)
                .MustAsync(async (root,command,context,cancellationToken) =>
                {
                    var user = await userManager.Users.AsNoTracking().SingleOrDefaultAsync(user => user.UserName == command.UserName);
                    if(user == null)
                    {
                        context.MessageFormatter.AppendArgument("messages", $"{command.UserName} is not found!");
                        return false;
                    }
                    if(user.ConfirmationEmailToken != command.EmailConfirmationToken)
                    {
                        context.MessageFormatter.AppendArgument("messages", "Email confirmation token does not match!");
                        return false;
                    }
                    return true;
                });
        }
    }
}
