using MediatR;

namespace Application.Dtos
{
	public class GetPost : IRequest<AppResponseDto>
	{
        public int PostId { get; private set; }

		public GetPost(int postId)
		{
			PostId = postId;
		}
	}
}
