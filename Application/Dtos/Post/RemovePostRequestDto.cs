using MediatR;

namespace Application.Dtos
{
	public class RemovePostRequestDto : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public RemovePostRequestDto(Guid postId)
		{
			PostId = postId;
		}
	}
}
