using AutoMapper;
using Models.Dtos;
using Models.Entities;

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
