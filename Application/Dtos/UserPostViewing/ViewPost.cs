using MediatR;

namespace Application.Dtos
{
	public class ViewPost : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public ViewPost(Guid postId)
		{
			PostId = postId;
		}
	}
}
