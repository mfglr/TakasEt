using MediatR;

namespace Application.Dtos
{
	public class RemoveComment : IRequest<AppResponseDto>
	{
        public int Id { get; private set; }

		public RemoveComment(int id){ Id = id; }
	}
}
