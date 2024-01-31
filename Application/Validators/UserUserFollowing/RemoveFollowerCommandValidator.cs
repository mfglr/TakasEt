using Models.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Application.Validators
{
	public class RemoveFollowerCommandValidator : AbstractValidator<DeleteFollowerDto>
	{
		public RemoveFollowerCommandValidator(IRepository<Following> followings)
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
