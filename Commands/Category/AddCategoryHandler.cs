using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Commands
{
    public class AddCategoryHandler : IRequestHandler<AddCategory, AppResponseDto>
    {
        private readonly IRepository<Category> _categories;
        private readonly IMapper _mapper;

        public AddCategoryHandler(IRepository<Category> categories, IMapper mapper)
        {
            _categories = categories;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(AddCategory request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            await _categories.DbSet.AddAsync(category, cancellationToken);
            return AppResponseDto.Success(
                _mapper.Map<CategoryResponseDto>(category)
                );
        }
    }
}
