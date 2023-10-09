using MediatR;

namespace Application.Dtos
{
    public class GetFirstImageOfPostsByUserIdRequestDto : IRequest<byte[]>
    {
        public Guid UserId { get; private set; }

        public GetFirstImageOfPostsByUserIdRequestDto(Guid userId)
        {
            UserId = userId;
        }
    }
}
