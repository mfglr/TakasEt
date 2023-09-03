using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands
{
	public class AddArticleHandler : IRequestHandler<AddArticleRequestDto, AddArticleResponseDto>
	{
		private readonly IRepository<Article> _articles;
		private readonly IMapper _mapper;

		public AddArticleHandler(IRepository<Article> articles, IMapper mapper)
		{
			_articles = articles;
			_mapper = mapper;
		}

		public async Task<AddArticleResponseDto> Handle(AddArticleRequestDto request, CancellationToken cancellationToken)
		{
			var article = new Article(request.UserId,request.Title,request.Content,request.SumaryOfContent,request.CategoryId);
			await _articles.AddAsync(article);
			return _mapper.Map<AddArticleResponseDto>(article);
		}
	}
}
