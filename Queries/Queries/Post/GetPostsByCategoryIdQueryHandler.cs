using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsByCategoryIdQueryHandler : IRequestHandler<GetPostsByCategoryId, AppResponseDto>
	{

		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<Post> _posts;

		public GetPostsByCategoryIdQueryHandler(LoggedInUser loggedInUser, IRepository<Post> posts)
		{
			_loggedInUser = loggedInUser;
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostsByCategoryId request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.IncludePost()
				.Where(post => post.CategoryId == request.CategoryId)
				.ToPage(request)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
