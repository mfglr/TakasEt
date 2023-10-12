using MediatR;

namespace Application.Dtos
{
	public class RemoveComment : IRequest<AppResponseDto>
	{
        public Guid Id { get; private set; }

		public RemoveComment(Guid id){ Id = id; }
	}
}
