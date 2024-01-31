using Models.Interfaces.Repositories;
using FluentValidation;
using Models.Dtos;
using Models.Entities;

namespace Application.Validators
{
	public class AddUserImageCommandValidator : AbstractValidator<AddUserImageDto>
	{
        public AddUserImageCommandValidator(IRepository<User> users)
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("error");
			RuleFor(x => x.Extention).NotNull().WithMessage("error");
			RuleFor(x => x.Stream).NotNull().WithMessage("error");
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, cancellationToken) => {
                    return await users.DbSet.FindAsync(userId, cancellationToken) != null;
                })
                .WithMessage("error");
        }
    }
}
