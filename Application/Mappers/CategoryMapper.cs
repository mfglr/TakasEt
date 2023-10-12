using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	internal class CategoryMapper : Profile
	{
        public CategoryMapper()
        {
            CreateMap<AddCategory, Category>();
            CreateMap<Category,CategoryResponseDto>();
        }

    }
}
