using MediatR;

namespace Application.Dtos
{
	public class RemoveArticleRequestDto : IRequest<AppResponseDto<NoContentResponseDto>>
	{
        public Guid Id { get; private set; }

		public RemoveArticleRequestDto(Guid id)
		{
			Id = id;
		}
	}
}
