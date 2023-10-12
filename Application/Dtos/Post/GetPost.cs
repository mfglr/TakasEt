using MediatR;

namespace Application.Dtos
{
	public class GetPost : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public GetPost(Guid postId)
		{
			PostId = postId;
		}
	}
}
