using MediatR;

namespace Models.Dtos
{
	public class GetConversationImageDto : IRequest<byte[]>
	{
		public int Id { get; private set; }

		public GetConversationImageDto(int id)
		{
			Id = id;
		}
	}
}
