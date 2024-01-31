using Models.Interfaces.Repositories;
using FluentValidation;
using Models.Dtos;
using Models.Entities;

namespace Application.Validators
{
	public class GetHomePageQueryValidator : AbstractValidator<GetHomePagePostsDto>
	{
		public GetHomePageQueryValidator(IRepository<User> users)
		{
			RuleFor(x => x.Take).NotNull().WithMessage("error");
			RuleFor(x => x.LoggedInUserId).NotNull().WithMessage("error");
			RuleFor(x => x.LoggedInUserId)
				.MustAsync(
					async (userId, cancellationToken) =>
					{
						return await users.DbSet.FindAsync(userId, cancellationToken) != null;
					}
				)
				.WithMessage("error");

		}
	}
}
