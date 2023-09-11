using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands
{
	public class AddArticleHandler : IRequestHandler<AddArticleRequestDto, AppResponseDto<AddArticleResponseDto>>
	{
		private readonly IRepository<Article> _articles;
		private readonly IMapper _mapper;

		public AddArticleHandler(IRepository<Article> articles, IMapper mapper)
		{
			_articles = articles;
			_mapper = mapper;
		}

		public async Task<AppResponseDto<AddArticleResponseDto>> Handle(AddArticleRequestDto request, CancellationToken cancellationToken)
		{
			var article = new Article(
				request.UserId,
				request.Title,
				request.Content,
				request.SumaryOfContent,
				request.CategoryId
			);
			await _articles.DbSet.AddAsync(article);
			return  AppResponseDto<AddArticleResponseDto>.Success(_mapper.Map<AddArticleResponseDto>(article));
		}
	}
}
