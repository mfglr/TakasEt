using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace Application.Validators
{
    public class FollowUserCommandValidator : AbstractValidator<FollowUser>
    {
		private static string[] messages =
		{
			"Validation Error : FollowUser => e0001",
			"Validation Error : FollowUser => e0002",
			"Validation Error : FollowUser => e0003",
		};

		public FollowUserCommandValidator(IRepository<UserUserFollowing> followings,LoggedInUser loggedInUser)
		{
			RuleFor(x => x.FollowedId).NotEmpty().NotNull().WithMessage(messages[0]);
			RuleFor(x => x.FollowedId).NotEqual(loggedInUser.UserId).WithMessage(messages[1]);
			RuleFor(x => x).MustAsync(
				async (request, cancellationToken) =>
				{
					return !await followings
						.DbSet
						.AnyAsync(
							x => 
								x.FollowedId == request.FollowedId && 
								x.FollowerId == loggedInUser.UserId,
							cancellationToken
						);
				}
			).WithMessage(messages[2]);
		}

	}
}
