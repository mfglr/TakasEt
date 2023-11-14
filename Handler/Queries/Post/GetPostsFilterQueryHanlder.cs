using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsFilterQueryHanlder : IRequestHandler<GetPostsByFilter,AppResponseDto>
	{
		private readonly IRepository<Post> _posts;

		public GetPostsFilterQueryHanlder(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostsByFilter request, CancellationToken cancellationToken)
		{
			var queryable = _posts.DbSet
				.AsNoTracking()
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.Category)
				.Include(x => x.User)
				.ThenInclude(x => x.Followeds)
				.Where(x => x.CreatedDate < request.getQueryDate());

			if (request.UserId != null)
				queryable = queryable.Where(x => x.UserId == request.UserId);
			if (request.Key != null)
				queryable = queryable.Where(x => x.NormalizedTitle.StartsWith(request.Key));
			if (request.CategoryId != null)
				queryable = queryable.Where(x => x.CategoryId == request.CategoryId);

			var posts = await queryable
				.OrderByDescending(x => x.CreatedDate)
				.ThenBy(x => x.Id)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToPostResponseDto()
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
