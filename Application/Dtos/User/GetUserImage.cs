using MediatR;

namespace Application.Dtos
{
	public class GetUserImage : IRequest<byte[]>
	{
        public int Id { get; set; }
    }
}
