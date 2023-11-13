using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserId, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		public GetPostsByUserIdQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostsByUserId request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.User)
				.Include(x => x.Category)
				.Where(post => post.UserId == request.UserId)
				.ToPage(x => x.Id,request)
				.Select(x => new PostResponseDto()
				{
					Id = x.Id,
					CreatedDate = x.CreatedDate,
					UpdatedDate = x.UpdatedDate,
					UserId = x.User.Id,
					UserName = x.User.UserName,
					CategoryName = x.Category.Name,
					Title = x.Title,
					Content = x.Content,
					PublishedDate = x.PublishedDate,
					CountOfImages = x.CountOfImages,
					CountOfLikes = x.UsersWhoLiked.Count,
					CountOfViews = x.UsersWhoViewed.Count,
					CountOfComments = x.Comments.Count,
				})
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
