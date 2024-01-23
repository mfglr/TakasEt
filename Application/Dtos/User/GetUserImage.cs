using MediatR;

namespace Application.Dtos
{
	public class GetUserImage : IRequest<byte[]>
	{
        public int Id { get; private set; }

		public GetUserImage(int id)
		{
			Id = id;
		}
	}
}
