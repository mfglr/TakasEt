using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class PostMapper : Profile
	{
        public PostMapper()
        {
            CreateMap<AddPostRequestDto, Post>();
            CreateMap<Post, GetPostCommentsResponseDto>();
            CreateMap<Post, PostResponseDto>();
        }
    }
}
