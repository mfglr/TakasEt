using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
    public class GetPostQueryHandler : IRequestHandler<GetPost, AppResponseDto>
    {
		private readonly IRepository<Post> _posts;

		public GetPostQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPost request, CancellationToken cancellationToken)
        {
			var post = await _posts
				.DbSet
				.AsNoTracking()
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.User)
				.Include(x => x.Category)
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
				.FirstOrDefaultAsync(post => post.Id == request.PostId, cancellationToken);
			if (post == null) throw new PostNotFoundException();
			return AppResponseDto.Success(post);
        }
    }
}
