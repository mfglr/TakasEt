using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class TagMapper : Profile
	{
        public TagMapper()
        {
            CreateMap<AddTagDto, Tag>();
        }

    }
}
