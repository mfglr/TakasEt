using MediatR;

namespace Application.Dtos
{
	public class GetPostComments : IRequest<AppResponseDto>
	{
		public Guid Id { get; private set; }

		public GetPostComments(Guid id)
		{
			Id = id;
		}
	}
}
