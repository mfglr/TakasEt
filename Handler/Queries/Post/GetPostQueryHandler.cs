using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Extentions;
using Application.Interfaces.Repositories;
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
				.Include(x => x.PostImages)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.User)
				.Include(x => x.Category)
				.ToPostResponseDto()
				.FirstOrDefaultAsync(post => post.Id == request.PostId, cancellationToken);
			if (post == null) throw new PostNotFoundException();
			return AppResponseDto.Success(post);
        }
    }
}
