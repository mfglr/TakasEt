using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryDto, AppResponseDto>
	{
		private readonly IRepository<Category> _categories;

		public DeleteCategoryCommandHandler(IRepository<Category> categories)
		{
			_categories = categories;
		}

		public async Task<AppResponseDto> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
		{
			var category = await _categories
				.DbSet
				.FindAsync(request.Id, cancellationToken);
			_categories.DbSet.Remove(category!);
			return AppResponseDto.Success();
		}
	}
}
