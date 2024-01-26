using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace Application.Mappers
{
    internal class CategoryMapper : Profile
	{
        public CategoryMapper()
        {
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category,CategoryResponseDto>();
        }

    }
}
