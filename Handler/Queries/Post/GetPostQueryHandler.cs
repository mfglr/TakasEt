using Application.Configurations;
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
		private readonly LoggedInUser _loggedInUser;
		public GetPostQueryHandler(IRepository<Post> posts, LoggedInUser loggedInUser)
		{
			_posts = posts;
			_loggedInUser = loggedInUser;
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
				.ThenInclude(x => x.ProfileImages)
				.Include(x => x.Category)
				.ToPostResponseDto(_loggedInUser.UserId)
				.SingleOrDefaultAsync(post => post.Id == request.PostId, cancellationToken);
			if (post == null) throw new PostNotFoundException();
			return AppResponseDto.Success(post);
        }
    }
}
