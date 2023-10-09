using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators
{
	public class AddSwapRequestsCommandValidator : AbstractValidator<AddSwapRequestsRequestDto>
	{

        private readonly IRepository<PostPostRequesting> _swapRequests;
		private readonly IRepository<Post> _posts;
        private readonly LoggedInUser _loggedInUser;

		public AddSwapRequestsCommandValidator(IRepository<PostPostRequesting> swapRequests, LoggedInUser loggedInUser, IRepository<Post> posts)
		{
			_swapRequests = swapRequests;
			_posts = posts;
			_loggedInUser = loggedInUser;

			RuleFor(x => x.RequestedId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.RequesterIds).NotNull().WithMessage("hata");
			RuleFor(x => x.RequesterIds.Count).GreaterThan(0).WithMessage("hata");
			RuleFor(x => x).Must(x => !x.RequesterIds.Contains(x.RequestedId)).WithMessage("hata");
			//ayni kayit
			RuleFor(x => x).MustAsync(async (dto, cancellationToken) =>
			{
				return !(
					await _swapRequests.DbSet.AnyAsync(
						entity =>
							entity.RequestedId == dto.RequestedId &&
							dto.RequesterIds.Contains(entity.RequesterId),
						cancellationToken
					)
				);
			}).WithMessage("hata");
			//kendi postuna istek yapamazsin ve isek yaptigin postlarin senin postlarin olmali
			RuleFor(x => x).MustAsync(async (dto, cancellationToken) =>
			{
				return !await _posts
					.DbSet
					.Where(post => dto.RequesterIds.Contains(post.Id) || dto.RequestedId == post.Id)
					.AnyAsync(post => post.UserId != _loggedInUser.UserId);
			}).WithMessage("hata");
		}
	}
}
