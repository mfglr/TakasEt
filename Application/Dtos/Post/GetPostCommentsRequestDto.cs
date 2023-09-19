using MediatR;

namespace Application.Dtos
{
	public class GetPostCommentsRequestDto : IRequest<AppResponseDto>
	{
		public Guid Id { get; private set; }

		public GetPostCommentsRequestDto(Guid id)
		{
			Id = id;
		}
	}
}
