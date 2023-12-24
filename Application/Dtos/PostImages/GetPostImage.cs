using MediatR;

namespace Application.Dtos
{
	public class GetPostImage : IRequest<byte[]>
	{
        public int Id { get; set; }
    }
}
