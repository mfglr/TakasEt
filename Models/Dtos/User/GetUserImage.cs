using MediatR;

namespace Models.Dtos
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
