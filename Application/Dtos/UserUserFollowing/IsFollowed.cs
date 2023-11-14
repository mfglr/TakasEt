using MediatR;

namespace Application.Dtos
{
	public class IsFollowed : IRequest<AppResponseDto>
	{
        public int UserId { get; private set; }

		public IsFollowed(int userId){ UserId = userId; }
	}
}
