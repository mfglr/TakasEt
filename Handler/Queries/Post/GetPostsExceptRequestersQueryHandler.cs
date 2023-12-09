using Application.Configurations;
using Application.Dtos;
using Application.Dtos.Post;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
    public class GetPostsExceptRequestersQueryHandler : IRequestHandler<GetPostsExceptRequesters, AppResponseDto>
    {
        private readonly IRepository<Post> _posts;
        private readonly LoggedInUser _loggedInUser;

        public GetPostsExceptRequestersQueryHandler( LoggedInUser loggedInUser, IRepository<Post> posts)
        {
            _loggedInUser = loggedInUser;
            _posts = posts;
        }
        public async Task<AppResponseDto> Handle(GetPostsExceptRequesters request, CancellationToken cancellationToken)
        {
            var posts = await _posts
                .DbSet
				.AsNoTracking()
                .Include(x => x.PostImages)
				.Include(x => x.Requesteds)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.Comments)
				.Include(x => x.User)
                .ThenInclude(x => x.ProfileImages)
				.Include(x => x.Category)
				.Include(x => x.Tags)
				.ThenInclude(x => x.Tag)
				.Where(
                    x =>
						x.UserId == _loggedInUser.UserId &&
                        !x.Requesteds.Select(r => r.RequestedId).Contains(request.PostId)
                )
				.ToPage(request)
				.ToPostResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
            return AppResponseDto.Success(posts);
        }
    }
}
