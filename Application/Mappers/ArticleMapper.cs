using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class ArticleMapper : Profile
	{
        public ArticleMapper()
        {
            CreateMap<AddPostRequestDto, Post>();
            CreateMap<Post,AddPostResponseDto>();
            CreateMap<Post, GetPostCommentsResponseDto>();
            CreateMap<Post, PostResponseDto>();
        }
    }
}
