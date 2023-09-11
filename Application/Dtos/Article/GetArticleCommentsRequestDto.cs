using MediatR;

namespace Application.Dtos
{
	public class GetArticleCommentsRequestDto : IRequest<AppResponseDto<GetArticleCommentsResponseDto>>
	{
		public Guid Id { get; private set; }

		public GetArticleCommentsRequestDto(Guid id)
		{
			Id = id;
		}
	}
}
