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
                    return user != null && user.ConfirmationEmailToken == command.EmailConfirmationToken && !user.EmailConfirmed;
                
                }).WithMessage("Invalid url!");
        }
    }
}
