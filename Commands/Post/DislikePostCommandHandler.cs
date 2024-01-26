using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class DislikePostCommandHandler : IRequestHandler<DislikePostDto, AppResponseDto>
    {
		private readonly IReadRepository<Post> _posts;

        public DislikePostCommandHandler(IReadRepository<Post> posts)
        {
			_posts = posts;
        }

        public async Task<AppResponseDto> Handle(DislikePostDto request, CancellationToken cancellationToken)
        {
            var post = await _posts.GetByIdAsync(request.PostId, cancellationToken);
            post!.Dislike(request.LoggedInUserId);
            return AppResponseDto.Success();
        }
    }
}
