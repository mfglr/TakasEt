using MediatR;

namespace Application.Dtos
{
    public class GetFirstImagesOfPostsByUserId : IRequest<byte[]>
    {
        public Guid UserId { get; private set; }

        public GetFirstImagesOfPostsByUserId(Guid userId){ UserId = userId; }
    }
}
