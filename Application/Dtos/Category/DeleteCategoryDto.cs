using MediatR;

namespace Application.Dtos
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
