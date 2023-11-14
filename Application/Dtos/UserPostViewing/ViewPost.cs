using MediatR;

namespace Application.Dtos
{
	public class ViewPost : IRequest<AppResponseDto>
	{
        public int PostId { get; private set; }

		public ViewPost(int postId)
		{
			PostId = postId;
		}
	}
}
