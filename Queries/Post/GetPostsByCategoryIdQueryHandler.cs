using Models.Extentions;
using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetPostsByCategoryIdQueryHandler : IRequestHandler<GetPostsByCategoryIdDto, AppResponseDto>
	{

		private readonly IRepository<Post> _posts;

		public GetPostsByCategoryIdQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostsByCategoryIdDto request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.IncludePost()
				.Where(post => post.CategoryId == request.CategoryId)
				.ToPage(request)
				.ToPostResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
