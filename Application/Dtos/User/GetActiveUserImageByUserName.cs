using MediatR;

namespace Application.Dtos
{
	public class GetActiveUserImageByUserName : IRequest<byte[]>
	{
        public string UserName { get; private set; }

		public GetActiveUserImageByUserName(string userName)
		{
			UserName = userName;
		}
	}
}
