using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

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
