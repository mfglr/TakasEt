using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetSearchPageQueryHandler : IRequestHandler<GetSearchPagePostsDto, AppResponseDto>
	{

		private readonly IRepository<Post> _posts;
		private readonly IRepository<User> _users;

		public GetSearchPageQueryHandler(IRepository<Post> posts, IRepository<User> users)
		{
			_posts = posts;
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetSearchPagePostsDto request, CancellationToken cancellationToken)
		{
			var categorIds = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.UserPostExplorings)
				.ThenInclude(x => x.Post)
				.ThenInclude(x => x.Tags)
				.Where(x => x.Id == request.LoggedInUserId)
				.Select(
					x => x.UserPostExplorings.OrderByDescending(x => x.CreatedDate).Take(5).Select(x => x.Post.CategoryId)
				)
				.FirstAsync();

			var posts = await _posts	
				.DbSet
				.IncludePost()
				.Where( post => categorIds.Count() == 0 || categorIds.Contains(post.CategoryId) )
				.ToPage(request)
				.ToPostResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
