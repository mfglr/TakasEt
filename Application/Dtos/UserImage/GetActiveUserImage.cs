using MediatR;

namespace Application.Dtos
{
    public class GetActiveUserImage : IRequest<Stream>
    {
        public int UserId { get; private set; }

        public GetActiveUserImage(int userId)
        {
            UserId = userId;
        }
    }
}
