using MediatR;

namespace Application.Dtos
{
	public class GetPostCommentsRequestDto : IRequest<AppResponseDto<GetPostCommentsResponseDto>>
	{
		public Guid Id { get; private set; }

		public GetPostCommentsRequestDto(Guid id)
		{
			Id = id;
		}
	}
}
