using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetSearchPostListPagePostsQueryHandler : IRequestHandler<GetSearchPostListPagePosts, AppResponseDto>
	{
		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<Post> _posts;

		public GetSearchPostListPagePostsQueryHandler(LoggedInUser loggedInUser, IRepository<Post> posts)
		{
			_loggedInUser = loggedInUser;
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetSearchPostListPagePosts request, CancellationToken cancellationToken)
		{
			var referansPost = await _posts
				.DbSet
				.Include(x => x.Tags)
				.ThenInclude(x => x.Tag)
				.FirstAsync(x => x.Id == request.PostId, cancellationToken);
			var tags = referansPost.Tags.Select(x => x.Tag.NormalizeName);
			var title = referansPost.NormalizedTitle;
			
			var posts = await _posts
				.DbSet
				.IncludePost()
				.Where(
					post => (
						post.CategoryId == referansPost.CategoryId ||
						post.Tags.Any(
							postTag => 
								title.Contains(postTag.Tag.NormalizeName) ||
								EF.Functions.Like(postTag.Tag.NormalizeName, string.Join(" OR ",tags.Select(x => $"%{x}%")))
						)
					)
				)
				.ToPage(request)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
