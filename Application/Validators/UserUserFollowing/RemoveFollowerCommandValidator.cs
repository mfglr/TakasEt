using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators
{
	public class RemoveFollowerCommandValidator : AbstractValidator<RemoveFollowerDto>
	{
		public RemoveFollowerCommandValidator(IRepository<UserUserFollowing> followings)
		{
			RuleFor(x => x.FollowerId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x).Must(x => x.LoggedInUserId != x.FollowerId).WithMessage("hata");
			RuleFor(x => x).MustAsync(async (request, cancellationToken) =>
			{
				return await followings.DbSet.AnyAsync(x => x.FollowerId == request.FollowerId && x.FollowingId == request.LoggedInUserId);
			});

		}
	}
}
