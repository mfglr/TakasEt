using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetNotSwappedPostsQueryHandler : IRequestHandler<GetNotSwappedPostsDto, AppResponseDto>
	{

		private readonly IRepository<Post> _posts;

		public GetNotSwappedPostsQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetNotSwappedPostsDto request, CancellationToken cancellationToken)
		{
			//var posts = await _posts
			//	.DbSet
			//	.AsNoTracking()
			//	.IncludePost()
			//	.Include(x => x.Swapping)
			//	.Where(x => x.UserId == request.UserId && x.Swapping == null)
			//	.ToPage(request)
			//	.ToPostResponseDto(_loggedInUser.UserId)
			//	.ToListAsync(cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
