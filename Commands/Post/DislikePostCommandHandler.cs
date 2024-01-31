using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class DislikePostCommandHandler : IRequestHandler<DislikePostDto, AppResponseDto>
    {
		private readonly IRepository<Post> _posts;

        public DislikePostCommandHandler(IRepository<Post> posts)
        {
			_posts = posts;
        }

        public async Task<AppResponseDto> Handle(DislikePostDto request, CancellationToken cancellationToken)
        {
            var post = await _posts
                .DbSet
                .FindAsync(request.PostId, cancellationToken);
            post!.Dislike(request.LoggedInUserId);
            return AppResponseDto.Success();
        }
    }
}
