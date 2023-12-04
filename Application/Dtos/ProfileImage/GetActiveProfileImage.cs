using MediatR;

namespace Application.Dtos
{
    public class GetActiveProfileImage : IRequest<Stream>
    {
        public int UserId { get; private set; }

        public GetActiveProfileImage(int userId)
        {
            UserId = userId;
        }
    }
}
