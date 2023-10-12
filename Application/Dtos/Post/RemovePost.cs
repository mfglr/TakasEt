using MediatR;

namespace Application.Dtos
{
	public class RemovePost : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public RemovePost(Guid postId)
		{
			PostId = postId;
		}
	}
}
