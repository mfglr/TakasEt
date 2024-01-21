using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class LikePostCommadHandler : IRequestHandler<LikePostDto, AppResponseDto>
    {
        private readonly IRepository<Post> _posts;
        public LikePostCommadHandler(IRepository<Post> posts)
        {
            _posts = posts;
        }

        public async Task<AppResponseDto> Handle(LikePostDto request, CancellationToken cancellationToken)
        {
            var post = await _posts.DbSet.FindAsync(request.PostId, cancellationToken);
            post!.Like((int)request.LoggedInUserId!);
            return AppResponseDto.Success();
        }
    }
}
