using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryDto, AppResponseDto>
	{
		private readonly IReadRepository<Category> _categories;

		public UpdateCategoryCommandHandler(IReadRepository<Category> categories)
		{
			_categories = categories;
		}

		public async Task<AppResponseDto> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
		{
			var category = await _categories.GetByIdAsync((int)request.Id!, cancellationToken);
			category!.Update(request.Name!);
			return AppResponseDto.Success();
		}
	}
}
