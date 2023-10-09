using MediatR;

namespace Application.Dtos
{
	public class GetPostsByUserIdRequestDto : IRequest<AppResponseDto>
	{
        public Guid UserId { get; private set; }

		public GetPostsByUserIdRequestDto(Guid userId)
		{
			UserId = userId;
		}
	}
}
