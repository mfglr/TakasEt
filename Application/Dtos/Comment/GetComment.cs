using MediatR;

namespace Application.Dtos
{
	public class GetComment : IRequest<AppResponseDto>
	{
        public Guid Id { get; private set; }
        public GetComment(Guid id)
        {
            Id = id;
        }
    }
}
