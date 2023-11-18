using MediatR;

namespace Application.Dtos
{
	public class GetAppFile : IRequest<byte[]>
	{
        public int Id { get; set; }

        public GetAppFile(int id)
        {
            Id = id;
        }
    }
}
