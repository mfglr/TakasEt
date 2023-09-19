using MediatR;

namespace Application.Dtos
{
	public class GetPostByIdRequestDto : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public GetPostByIdRequestDto(Guid postId)
		{
			PostId = postId;
		}
	}
}
