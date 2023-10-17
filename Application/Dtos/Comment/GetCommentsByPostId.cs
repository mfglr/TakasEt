using MediatR;

namespace Application.Dtos
{
	public class GetCommentsByPostId : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public GetCommentsByPostId(Guid postId)
		{
			PostId = postId;
		}
	}
}
