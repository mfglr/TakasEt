using MediatR;

namespace Application.Dtos
{
	public class GetUserByUserName : IRequest<AppResponseDto>
	{
        public string UserName { get; private set; }
        
        public GetUserByUserName(string userName)
        {
            UserName = userName;
        }
    }
}
