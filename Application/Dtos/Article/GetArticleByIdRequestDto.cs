using MediatR;

namespace Application.Dtos
{
	public class GetArticleByIdRequestDto : IRequest<AppResponseDto<ArticleResponseDto>>
	{
        public Guid Id { get; private set; }

		public GetArticleByIdRequestDto(Guid id)
		{
			Id = id;
		}
	}
}
