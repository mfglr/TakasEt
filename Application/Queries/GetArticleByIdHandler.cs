using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetArticleByIdHandler : IRequestHandler<GetArticleByIdRequestDto, AppResponseDto<ArticleResponseDto>>
	{
		private readonly IRepository<Article> _articles;
		private readonly RecursiveRepositoryOptions _option;
		private readonly IMapper _mapper;

		public GetArticleByIdHandler(IRepository<Article> articles, IMapper mapper, RecursiveRepositoryOptions option)
		{
			_articles = articles;
			_mapper = mapper;
			_option = option;
		}

		public async Task<AppResponseDto<ArticleResponseDto>> Handle(GetArticleByIdRequestDto request, CancellationToken cancellationToken)
		{
			var article = await _articles.DbSet
				.Include(x => x.Comments)
				.ThenIncludeChildrenByRecursive(_option.Depth)
				.FirstOrDefaultAsync(x => x.Id == request.Id);
			return AppResponseDto<ArticleResponseDto>.Success(
				_mapper.Map<ArticleResponseDto>(article)
				);
		}
	}
}
