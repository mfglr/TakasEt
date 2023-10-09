using MediatR;

namespace Application.Dtos
{
    public class GetRequesterPostsRequestDto : IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }

        public GetRequesterPostsRequestDto(Guid postId)
        {
            PostId = postId;
        }
    }
}
