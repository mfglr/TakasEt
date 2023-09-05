using MediatR;

namespace Application.Dtos
{
	public class RemoveCommentRequestDto : IRequest<NoContentResponseDto>
	{
        public Guid Id { get; private set; }

		public RemoveCommentRequestDto(Guid id)
		{
			Id = id;
		}
	}
}
