using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetArticleByIdHandler : IRequestHandler<GetArticleByIdRequestDto, ArticleResponseDto>
	{
		private readonly IRepository<Article> _articles;

		private readonly IMapper _mapper;

		public GetArticleByIdHandler(IRepository<Article> articles, IMapper mapper)
		{
			_articles = articles;
			_mapper = mapper;
		}

		public async Task<ArticleResponseDto> Handle(GetArticleByIdRequestDto request, CancellationToken cancellationToken)
		{
			var article = await _articles.DbSet
				.Include(x => x.Comments)
				.ThenIncludeChildrenByRecursive(3)
				.FirstOrDefaultAsync(x => x.Id == request.Id);
			return _mapper.Map<ArticleResponseDto>(article);
		}
	}
}
