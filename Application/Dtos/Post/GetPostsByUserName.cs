using MediatR;

namespace Application.Dtos
{
	public class GetPostsByUserName : IRequest<AppResponseDto>
	{
        public string UserName { get; private set; }

		public GetPostsByUserName(string userName)
		{
			UserName = userName;
		}
	}
}
