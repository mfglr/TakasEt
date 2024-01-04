using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetExplorePagePostsQueryHandler : IRequestHandler<GetExplorePagePosts, AppResponseDto>
	{
		private readonly LoggedInUser _loggedInUser;
		private IRepository<Post> _posts;

		public GetExplorePagePostsQueryHandler(LoggedInUser loggedInUser, IRepository<Post> posts)
		{
			_loggedInUser = loggedInUser;
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetExplorePagePosts request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.IncludePost()
				.Where(
					x =>
						(request.CategoryId == null || x.CategoryId == request.CategoryId) &&
						(
							request.Tags == null || 
							x.Tags.Any( pt => request.Tags.Any( tag => pt.Tag.NormalizeName.Contains(tag) ) )
						)
				)
				.ToPage(request)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);

		}
	}
}
