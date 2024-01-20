using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetSearchPostListPagePostsQueryHandler : IRequestHandler<GetSearchPostListPagePostsDto, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;

		public GetSearchPostListPagePostsQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetSearchPostListPagePostsDto request, CancellationToken cancellationToken)
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
				.ToPostResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
