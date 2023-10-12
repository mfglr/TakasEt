using MediatR;

namespace Application.Dtos
{
	//Belirli bir postun requester postlarini verir.
	public class GetRequesters : IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }

        public GetRequesters(Guid postId){ PostId = postId; }
    }
}
