using Models.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryDto, AppResponseDto>
    {
        private readonly IRepository<Category> _categories;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(IRepository<Category> categories, IMapper mapper)
        {
			_categories = categories;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(AddCategoryDto request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            await _categories.DbSet.AddAsync(category, cancellationToken);
            return AppResponseDto.Success( _mapper.Map<CategoryResponseDto>(category) );
        }
    }
}
