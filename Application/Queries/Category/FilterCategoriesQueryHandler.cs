using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class FilterCategoriesQueryHandler : IRequestHandler<FilterCategories, AppResponseDto>
    {

        private readonly IRepository<Category> _categories;
        private readonly IMapper _mapper;

        public FilterCategoriesQueryHandler(IRepository<Category> categories, IMapper mapper)
        {
			_categories = categories;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(FilterCategories request, CancellationToken cancellationToken)
        {
            var categories = await _categories
				.DbSet
                .Where(c =>
                    
                        request.Key == null ||
                        c.Name.ToLower().Contains(request.Key.ToLower()) ||
                        c.Description.ToLower().Contains(request.Key.ToLower())
                    
                ).ToListAsync();
            return AppResponseDto.Success(_mapper.Map<IEnumerable<CategoryResponseDto>>(categories));
        }
    }
}
