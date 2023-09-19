using MediatR;

namespace Application.Dtos
{
	public class GetCommentByIdRequestDto : IRequest<AppResponseDto>
	{
        public Guid Id { get; private set; }
        public GetCommentByIdRequestDto(Guid id)
        {
            Id = id;
        }
    }
}
