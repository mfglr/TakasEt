using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesDto, AppResponseDto>
	{
		private readonly IRepository<Category> _categories;
		private readonly IMapper _mapper;

		public GetCategoriesQueryHandler(IRepository<Category> categories, IMapper mapper)
		{
			_categories = categories;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetCategoriesDto request, CancellationToken cancellationToken)
		{
			var categories = await _categories
				.DbSet
				.ToPage(request)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success( _mapper.Map<List<CategoryResponseDto>>(categories) );
		}
	}
}
