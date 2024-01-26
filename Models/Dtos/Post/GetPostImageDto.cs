using MediatR;

namespace Models.Dtos
{
	public class GetPostImageDto : IRequest<byte[]>
	{
        public int Id { get; set; }
    }
}
