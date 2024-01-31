using Models.Extentions;
using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetUserPostsQueryHandler : IRequestHandler<GetUserPostsDto, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		public GetUserPostsQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetUserPostsDto request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.IncludePost()
				.Where(post => post.UserId == request.UserId)
				.ToPage(request)
				.ToPostResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
