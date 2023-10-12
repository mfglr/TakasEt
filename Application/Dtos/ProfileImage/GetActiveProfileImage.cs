using MediatR;

namespace Application.Dtos
{
    public class GetActiveProfileImage : IRequest<byte[]>
    {
        public Guid UserId { get; private set; }

        public GetActiveProfileImage(Guid userId)
        {
            UserId = userId;
        }
    }
}
