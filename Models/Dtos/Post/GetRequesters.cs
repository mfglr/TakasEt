using MediatR;

namespace Models.Dtos
{
	//Belirli bir postun requester postlarini verir.
	public class GetRequesters : IRequest<AppResponseDto>
    {
        public int PostId { get; private set; }

        public GetRequesters(int postId){ PostId = postId; }
    }
}
