using MediatR;

namespace Application.Dtos
{
	public class IsFollowed : IRequest<AppResponseDto>
	{
        public Guid UserId { get; private set; }

		public IsFollowed(Guid userId){ UserId = userId; }
	}
}
