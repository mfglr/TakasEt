using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
    public class FilterCategoriesQueryHandler : IRequestHandler<FilterCategoriesDto, AppResponseDto>
    {

        private readonly IRepository<Category> _categories;
        private readonly IMapper _mapper;

        public FilterCategoriesQueryHandler(IRepository<Category> categories, IMapper mapper)
        {
			_categories = categories;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(FilterCategoriesDto request, CancellationToken cancellationToken)
        {
            var categories = await _categories
				.DbSet
				.AsNoTracking()
				.Where(
                    c =>
                        request.Key == null ||
                        c.Name.ToLower().Contains(request.Key.ToLower())
                )
                .ToPage(request)
                .ToListAsync();
            return AppResponseDto.Success(_mapper.Map<IEnumerable<CategoryResponseDto>>(categories));
        }
    }
}
