using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryDto, AppResponseDto>
    {
        private readonly IWriteRepository<Category> _categories;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(IWriteRepository<Category> categories, IMapper mapper)
        {
			_categories = categories;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(AddCategoryDto request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            await _categories.CreateAsync(category, cancellationToken);
            return AppResponseDto.Success( _mapper.Map<CategoryResponseDto>(category) );
        }
    }
}
