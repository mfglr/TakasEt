using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands
{
	public class AddCategoryHandler : IRequestHandler<AddCategoryRequestDto,  AppResponseDto>
	{
		private readonly IRepository<Category> _categories;
		private readonly IMapper _mapper;

		public AddCategoryHandler(IRepository<Category> categories, IMapper mapper)
		{
			_categories = categories;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(AddCategoryRequestDto request, CancellationToken cancellationToken)
		{
			var category = new Category(request.Name, request.Description);
			await _categories.DbSet.AddAsync(category);
			return AppResponseDto.Success(
				_mapper.Map<AddCategoryResponseDto>(category)
				);
		}
	}
}
