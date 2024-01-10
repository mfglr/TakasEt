using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetFilterPagePostsQueryHandler : IRequestHandler<GetFilterPagePosts, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly LoggedInUser _loggedInUser;

		public GetFilterPagePostsQueryHandler(IRepository<Post> posts, LoggedInUser loggedInUser)
		{
			_posts = posts;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetFilterPagePosts request, CancellationToken cancellationToken)
		{
			string? normalizeKey = request.Key.CustomNormalize();
			
			var posts = await _posts
				.DbSet
				.IncludePost()
				.Where(post => 
					(
						(
							request.CategoryIds == null ||
							request.CategoryIds.Contains(post.CategoryId)
						) &&
						(
							normalizeKey == null ||
							post.NormalizedTitle.Contains( normalizeKey ) ||
							post.Tags.Any( pt => pt.Tag.NormalizeName.Contains(normalizeKey) )
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
