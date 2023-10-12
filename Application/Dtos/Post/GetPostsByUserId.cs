using MediatR;

namespace Application.Dtos
{
	public class GetPostsByUserId : IRequest<AppResponseDto>
	{
        public Guid UserId { get; private set; }

		public GetPostsByUserId(Guid userId)
		{
			UserId = userId;
		}
	}
}
