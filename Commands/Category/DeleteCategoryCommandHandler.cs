using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryDto, AppResponseDto>
	{
		private readonly IWriteRepository<Category> _categories;

		public DeleteCategoryCommandHandler(IWriteRepository<Category> categories)
		{
			_categories = categories;
		}

		public async Task<AppResponseDto> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
		{
			await _categories.DeleteAsync(request.Id, cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
