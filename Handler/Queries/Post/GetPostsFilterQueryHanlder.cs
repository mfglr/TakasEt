using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsFilterQueryHanlder : IRequestHandler<GetPostsByFilter,AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly LoggedInUser _loggedInUser;

		public GetPostsFilterQueryHanlder(IRepository<Post> posts, LoggedInUser loggedInUser)
		{
			_posts = posts;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetPostsByFilter request, CancellationToken cancellationToken)
		{
			var queryable = _posts.DbSet
				.AsNoTracking()
				.Include(x => x.PostImages)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.Category)
				.Include(x => x.User)
				.ThenInclude(x => x.ProfileImages);

			if (request.IncludeFolloweds)
			{
				queryable
					.Include(x => x.User)
					.ThenInclude(x => x.Followeds)
					.Where(
						x =>
							x.CreatedDate < request.getQueryDate() &&
							x.User.Followers.Any(x => x.FollowerId == _loggedInUser.UserId)
					);
			}
			else if (request.IncludeLastSearchigns)
			{
				queryable
					.Include(x => x.User)
					.ThenInclude(x => x.Searchings)
					.Where(
						post =>
							post.CreatedDate < request.getQueryDate() &&
							post.User.Searchings.Any(x => post.NormalizedTitle.StartsWith(x.NormalizeKey))
					);
			}
			else if(request.UserId != null)
				queryable.Where(x => x.UserId == request.UserId);
			else if(request.Key != null)
				queryable.Where(x => x.NormalizedTitle.StartsWith(request.Key));
			else if (request.CategoryId != null)
				queryable.Where(x => x.CategoryId == request.CategoryId);
			
			var posts = await queryable
				.OrderByDescending(x => x.CreatedDate)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
