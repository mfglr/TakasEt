using MediatR;

namespace Models.Dtos
{
	public class DeleteTagDto : IRequest<AppResponseDto>
	{
		public int Id { get; private set; }

        public DeleteTagDto(int id)
        {
            Id = id;
        }
    }
}
