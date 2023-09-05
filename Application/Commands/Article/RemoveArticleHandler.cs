using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class RemoveArticleHandler : IRequestHandler<RemoveArticleRequestDto, NoContentResponseDto>
	{
		private readonly IRepository<Article> _articles;
		private readonly RecursiveRepositoryOptions _option;
		public RemoveArticleHandler(IRepository<Article> articles,RecursiveRepositoryOptions option)
		{
			_articles = articles;
			_option = option;
		}

		public async Task<NoContentResponseDto> Handle(RemoveArticleRequestDto request, CancellationToken cancellationToken)
		{
			var article = await _articles.Where(x => x.Id == request.Id).Include(x => x.Comments).GetEntityWithRecursiveEntitiesAsync(_option, request.Id);
			
		}
	}
}
