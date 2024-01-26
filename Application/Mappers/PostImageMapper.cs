using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace Application.Mappers
{
	public class PostImageMapper : Profile
	{
		public PostImageMapper() {
			CreateMap<PostImage, PostImageResponseDto>();
		}
	}
}
