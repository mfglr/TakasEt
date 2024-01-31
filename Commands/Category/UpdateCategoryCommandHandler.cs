using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryDto, AppResponseDto>
	{
		private readonly IRepository<Category> _categories;

		public UpdateCategoryCommandHandler(IRepository<Category> categories)
		{
			_categories = categories;
		}

		public async Task<AppResponseDto> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
		{
			var category = await _categories
				.DbSet
				.FindAsync((int)request.Id!, cancellationToken);
			category!.Update(request.Name!);
			return AppResponseDto.Success();
		}
	}
}
