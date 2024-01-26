using Models.Dtos;
using Models.Entities;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators
{
	public class AddRequestingsCommandValidator : AbstractValidator<AddRequestings>
	{

        private readonly IRepository<Requesting> _swapRequests;
		private readonly IRepository<Post> _posts;

		public AddRequestingsCommandValidator(IRepository<Requesting> swapRequests, IRepository<Post> posts)
		{
			_swapRequests = swapRequests;
			_posts = posts;

			RuleFor(x => x.RequestedId).NotEmpty().NotNull().WithMessage("hata : 0");
			RuleFor(x => x.RequesterIds).NotNull().WithMessage("hata : 1");
			RuleFor(x => x.RequesterIds.Count).GreaterThan(0).WithMessage("hata : 2");
			RuleFor(x => x).Must(x => !x.RequesterIds.Contains(x.RequestedId)).WithMessage("hata : 3");
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
			}).WithMessage("hata : 4");
			//kendi post una istek yapamazsin ya da
			//kendi postun ile bir baska post a istek yapabilirsin 
			RuleFor(x => x).MustAsync(async (dto, cancellationToken) =>
			{
				return !await _posts
					.DbSet
					.AnyAsync(
						post => post.UserId == dto.LoggedInUserId && 
						(dto.RequestedId == post.Id || !dto.RequesterIds.Contains(post.Id)),
						cancellationToken
					);
			}).WithMessage("hata : 5");
		}
	}
}
