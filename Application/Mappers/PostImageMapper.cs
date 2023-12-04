using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class PostImageMapper : Profile
	{
		public PostImageMapper() {
			CreateMap<PostImage, PostImageResponseDto>();
		}
	}
}
