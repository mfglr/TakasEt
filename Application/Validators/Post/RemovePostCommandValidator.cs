using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators
{
    public class RemovePostCommandValidator : AbstractValidator<RemovePost>
    {
		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<Post> _posts;

		public RemovePostCommandValidator(LoggedInUser loggedInUser, IRepository<Post> posts)
		{
			_loggedInUser = loggedInUser;
			_posts = posts;

			RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x).MustAsync(async (x, cancellationToken) =>
			{
				var post = await _posts.DbSet.FirstOrDefaultAsync(p => p.Id == x.PostId);
				return post != null && post.UserId == _loggedInUser.UserId;
			}).WithMessage("hata");
		}
	}
}
