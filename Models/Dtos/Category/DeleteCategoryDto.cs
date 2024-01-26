using MediatR;

namespace Models.Dtos
{
	public class DeleteCategoryDto : IRequest<AppResponseDto>
	{
		public int Id { get; private set; }

        public DeleteCategoryDto(int id)
        {
            Id = id;
        }
    }
}
