using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsByKeyQueryHandler : IRequestHandler<GetPostsByKey, AppResponseDto>
	{

		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<Post> _posts;

		public GetPostsByKeyQueryHandler(LoggedInUser loggedInUser, IRepository<Post> posts)
		{
			_loggedInUser = loggedInUser;
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostsByKey request, CancellationToken cancellationToken)
		{

			var normalizeKey = request.Key.CustomNormalize();
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.IncludePost()
				.Where(
					post => (
						normalizeKey == null ||
						normalizeKey == "" ||
						post.NormalizedTitle.Contains(normalizeKey) ||
						post.Tags.Any(postTag => postTag.Tag.NormalizeName.Contains(normalizeKey))
					)
				)
				.ToPage(request)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);

		}
	}
}
