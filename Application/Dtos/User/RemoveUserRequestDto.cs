using MediatR;

namespace Application.Dtos
{
	public class RemoveUserRequestDto : IRequest<NoContentResponseDto>
	{
        public Guid Id { get; private set; }
        public RemoveUserRequestDto(Guid id)
        {
            Id = id;
        }
    }
}
