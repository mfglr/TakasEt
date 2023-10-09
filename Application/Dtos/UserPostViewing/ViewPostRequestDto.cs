using MediatR;

namespace Application.Dtos
{
	public class ViewPostRequestDto : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public ViewPostRequestDto(Guid postId)
		{
			PostId = postId;
		}
	}
}
