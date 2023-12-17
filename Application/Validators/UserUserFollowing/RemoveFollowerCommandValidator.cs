using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators
{
	public class RemoveFollowerCommandValidator : AbstractValidator<RemoveFollower>
	{
		public RemoveFollowerCommandValidator(LoggedInUser loggedInUser,IRepository<UserUserFollowing> followings)
		{
			RuleFor(x => x.FollowerId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.FollowerId).NotEqual(loggedInUser.UserId).WithMessage("hata");
			RuleFor(x => x).MustAsync(async (request, cancellationToken) =>
			{
				return await followings.DbSet.AnyAsync(x => x.FollowerId == request.FollowerId && x.FollowedId == loggedInUser.UserId);
			});

		}
	}
}
