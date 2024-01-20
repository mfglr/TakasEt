using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetFilterPagePostsQueryHandler : IRequestHandler<GetFilterPagePostsDto, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;

		public GetFilterPagePostsQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetFilterPagePostsDto request, CancellationToken cancellationToken)
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
				.ToPostResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
