using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class ArticleMapper : Profile
	{
        public ArticleMapper()
        {
            CreateMap<AddArticleRequestDto, Article>();
            CreateMap<Article,AddArticleResponseDto>();
            CreateMap<Article, GetArticleCommentsResponseDto>();
        }
    }
}
