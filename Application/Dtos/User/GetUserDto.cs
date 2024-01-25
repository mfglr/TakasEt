using MediatR;

namespace Application.Dtos
{
	public class GetUserDto :  IRequest<AppResponseDto>
    {
        public int LoggedInUserId { get; private set; }

        public GetUserDto(int loggedInUserId)
        {
            LoggedInUserId = loggedInUserId;
        }
    }
}
