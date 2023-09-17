using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequestDto, AppResponseDto<PostResponseDto>>
	{
		private readonly IRepository<Post> _posts;

		public GetPostByIdHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto<PostResponseDto>> Handle(GetPostByIdRequestDto request, CancellationToken cancellationToken)
		{
			var post = await _posts
				.DbSet
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Where(x => x.Id == request.PostId)
				.Select(
					x => new PostResponseDto(
						x.Id,
						x.Title,
						x.Content,
						x.UsersWhoLiked.Count,
						x.UsersWhoViewed.Count,
						x.PublishedDate,
						x.CategoryId
					)
				)
				.FirstOrDefaultAsync();
			if (post == null) throw new PostNotFoundException();
			return AppResponseDto<PostResponseDto>.Success(post);
		}
	}
}
