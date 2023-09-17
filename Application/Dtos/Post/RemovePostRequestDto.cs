using MediatR;

namespace Application.Dtos
{
	public class RemovePostRequestDto : IRequest<AppResponseDto<NoContentResponseDto>>
	{
        public Guid PostId { get; private set; }

		public RemovePostRequestDto(Guid postId)
		{
			PostId = postId;
		}
	}
}
