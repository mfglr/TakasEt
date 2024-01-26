using MediatR;

namespace Models.Dtos
{
	public class RemoveCommentDto : IRequest<AppResponseDto>
	{
        public int Id { get; private set; }

		public RemoveCommentDto(int id){ Id = id; }
	}
}
