using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequestDto, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;

		public GetPostByIdHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostByIdRequestDto request, CancellationToken cancellationToken)
		{
			var post = await _posts
				.DbSet
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Where(x => x.Id == request.PostId)
				.Select(
					x => new PostResponseDto() {
						UserId = x.UserId,
						Id = x.Id,
						Title = x.Title,
						Content = x.Content,
						CountOfLikes = x.UsersWhoLiked.Count,
						CountOfViews = x.UsersWhoViewed.Count,
						CategoryId = x.CategoryId,
						CreatedDate = x.CreatedDate
					}
				)
				.FirstOrDefaultAsync();
			if (post == null) throw new PostNotFoundException();
			return AppResponseDto.Success(post);
		}
	}
}
