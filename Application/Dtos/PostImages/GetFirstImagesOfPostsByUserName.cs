using MediatR;

namespace Application.Dtos
{
	public class GetFirstImagesOfPostsByUserName : IRequest<byte[]>
	{
        public string UserName { get; private set; }

		public GetFirstImagesOfPostsByUserName(string userName)
		{
			UserName = userName;
		}
	}
}
