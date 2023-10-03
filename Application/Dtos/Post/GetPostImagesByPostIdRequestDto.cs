using MediatR;

namespace Application.Dtos
{
    public class GetPostImagesByPostIdRequestDto : IRequest<byte[]>
    {
        public Guid PostId { get; private set; }

        public GetPostImagesByPostIdRequestDto(Guid postId)
        {
            PostId = postId;
        }
    }
}
