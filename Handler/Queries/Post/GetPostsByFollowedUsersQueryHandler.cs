using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsByFollowedUsersQueryHandler : IRequestHandler<GetPostsByFollowedUsers, byte[]>
	{
		private readonly IRepository<Post> _posts;
		private readonly LoggedInUser _loggedInUser;
		private readonly IFileWriterService _writerService;

		public GetPostsByFollowedUsersQueryHandler(IRepository<Post> posts, LoggedInUser loggedInUser, IFileWriterService writerService)
		{
			_posts = posts;
			_loggedInUser = loggedInUser;
			_writerService = writerService;
		}

		public async Task<byte[]> Handle(GetPostsByFollowedUsers request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.Include(x => x.PostImages)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.Category)
				.Include(x => x.User)
				.ThenInclude(x => x.Followers)
				.Where(
					x =>
						(x.CreatedDate < request.getQueryDate()) && 
						(x.User.Followers.Any(x => x.FollowerId == _loggedInUser.UserId))
				)
				.OrderByDescending(x => x.CreatedDate)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToPostResponseDto()
				.ToListAsync(cancellationToken);
			await _writerService.WritePostListAsync(posts, cancellationToken);
			return _writerService.Bytes;
		}
	}
}
