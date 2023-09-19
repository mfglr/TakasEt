using MediatR;

namespace Application.Dtos
{
	public class GetUserByUserNameRequestDto : IRequest<AppResponseDto>
	{
        public string UserName { get; private set; }
        
        public GetUserByUserNameRequestDto(string userName)
        {
            UserName = userName;
        }
    }
}
