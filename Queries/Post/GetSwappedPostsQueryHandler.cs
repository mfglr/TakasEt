using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetSwappedPostsQueryHandler : IRequestHandler<GetSwappedPostsDto, AppResponseDto>
	{

		private readonly IRepository<Post> _posts;

		public GetSwappedPostsQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetSwappedPostsDto request, CancellationToken cancellationToken)
		{
			//var posts = await _posts
			//	.DbSet
			//	.AsNoTracking()
			//	.IncludePost()
			//	.Include(x => x.)
			//	.Where( x => x.UserId == request.UserId && x.Swapping != null)
			//	.ToPage(request)
			//	.ToPostResponseDto(_loggedInUser.UserId)
			//	.ToListAsync(cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
