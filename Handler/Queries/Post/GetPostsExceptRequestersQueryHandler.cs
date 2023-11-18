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
    //*Belirli bir posta !!!herhangi bir post degil!!!, giris yapmis kullanicinin postlari
    // arasindaki, requester olmayan postlari verir.
    //*Post u id si ile belirler.

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
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.User)
				.Include(x => x.Category)
				.Where(
                    x =>
						x.CreatedDate < request.getQueryDate() &&
						x.UserId == _loggedInUser.UserId &&
                        !x.Requesteds.Select(r => r.RequestedId).Contains(request.PostId)
                )
				.OrderByDescending(x => x.CreatedDate)
                .Skip(request.Skip)
                .Take(request.Take)
				.ToPostResponseDto()
				.ToListAsync(cancellationToken);
            return AppResponseDto.Success(posts);
        }
    }
}
