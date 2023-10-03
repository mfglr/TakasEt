using MediatR;

namespace Application.Dtos
{
    public class GetActiveProfileImageByIdRequestDto : IRequest<byte[]>
    {
        public Guid UserId { get; private set; }

        public GetActiveProfileImageByIdRequestDto(Guid userId)
        {
            UserId = userId;
        }
    }
}
