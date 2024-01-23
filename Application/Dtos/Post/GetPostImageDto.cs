using MediatR;

namespace Application.Dtos
{
	public class GetPostImageDto : IRequest<byte[]>
	{
        public int Id { get; set; }
    }
}
