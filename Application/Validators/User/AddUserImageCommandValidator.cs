using Application.Helpers;
using Application.Interfaces.Repositories;
using FluentValidation;
using Models.Dtos;
using Models.Entities;

namespace Application.Validators
{
	public class AddUserImageCommandValidator : AbstractValidator<AddUserImageDto>
	{
        public AddUserImageCommandValidator(IRepository<User> users)
        {
            string dto = "AddUserImageDto";
            RuleFor(x => x.UserId).NotNull().WithMessage(CreateMessageHelper.RunHelper(dto,"UserId", "User id is required!"));
			RuleFor(x => x.Extention).NotNull().WithMessage(CreateMessageHelper.RunHelper(dto,"Extention", "Extention is required!"));
			RuleFor(x => x.Stream).NotNull().WithMessage(CreateMessageHelper.RunHelper(dto,"Stream", "Stream is required!"));
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, cancellationToken) => {
                    return await users.DbSet.FindAsync(userId, cancellationToken) != null;
                })
                .WithMessage(CreateMessageHelper.RunHelper(dto, "UserId", "User not found!"));
        }
    }
}
