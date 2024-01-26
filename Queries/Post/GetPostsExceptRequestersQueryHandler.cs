using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
    public class GetPostsExceptRequestersQueryHandler : IRequestHandler<GetPostsExceptRequestersDto, AppResponseDto>
    {
        private readonly IRepository<Post> _posts;

        public GetPostsExceptRequestersQueryHandler(IRepository<Post> posts)
        {
            _posts = posts;
        }
        public async Task<AppResponseDto> Handle(GetPostsExceptRequestersDto request, CancellationToken cancellationToken)
        {
    //        var posts = await _posts
    //            .DbSet
				//.AsNoTracking()
    //            .IncludePost()
				//.Include(x => x.RequestedPosts)
				//.Where(
    //                x =>
				//		x.UserId == request.LoggedInUserId &&
    //                    !x.RequestedPosts.Select(r => r.RequestedId).Contains(request.PostId)
    //            )
				//.ToPage(request)
				//.ToPostResponseDto(request.LoggedInUserId)
				//.ToListAsync(cancellationToken);
            return AppResponseDto.Success();
        }
    }
}
