using MediatR;

namespace Application.Dtos
{
	public class GetActiveProfileImageByUserName : IRequest<byte[]>
	{
        public string UserName { get; private set; }

		public GetActiveProfileImageByUserName(string userName)
		{
			UserName = userName;
		}
	}
}
