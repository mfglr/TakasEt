using MediatR;

namespace Application.Dtos
{
    
    public class GetPostImages : IRequest<byte[]>
    {
        public Guid PostId { get; private set; }

        public GetPostImages(Guid postId){ PostId = postId; }
    }
}
