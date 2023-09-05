using MediatR;

namespace Application.Dtos
{
	public class GetArticleCommentsRequestDto : IRequest<GetArticleCommentsResponseDto>
	{
		public Guid Id { get; private set; }

		public GetArticleCommentsRequestDto(Guid id)
		{
			Id = id;
		}
	}
}
