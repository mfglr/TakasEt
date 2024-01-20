using Application.Dtos;
using Application.Entities;
using AutoMapper;

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
