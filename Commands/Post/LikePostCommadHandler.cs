using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

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
            var post = await _posts
                .DbSet
                .FindAsync((int)request.PostId!, cancellationToken);

            post!.Like((int)request.LoggedInUserId!);
            return AppResponseDto.Success();
        }
    }
}
