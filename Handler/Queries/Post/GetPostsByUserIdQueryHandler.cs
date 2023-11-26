using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserId, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly LoggedInUser _loggedInUser;
		public GetPostsByUserIdQueryHandler(IRepository<Post> posts, LoggedInUser loggedInUser)
		{
			_posts = posts;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetPostsByUserId request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.Include(x => x.PostImages)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.User)
				.Include(x => x.Category)
				.Where(post => post.CreatedDate < request.getQueryDate() && post.UserId == request.UserId)
				.OrderByDescending(x => x.CreatedDate)
				.ThenBy(x => x.Id)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
