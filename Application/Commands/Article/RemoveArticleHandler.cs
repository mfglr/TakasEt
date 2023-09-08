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
		private readonly IRepository<Comment> _comments;
		private readonly RecursiveRepositoryOptions _option;
		public RemoveArticleHandler(IRepository<Article> articles, RecursiveRepositoryOptions option, IRepository<Comment> comments)
		{
			_articles = articles;
			_option = option;
			_comments = comments;
		}

		public async Task<NoContentResponseDto> Handle(RemoveArticleRequestDto request, CancellationToken cancellationToken)
		{
			var article = await _articles
				.DbSet
				.Include(x => x.Comments)
				.ThenIncludeChildrenByRecursive(_option.Depth)
				.FirstOrDefaultAsync(x => x.Id == request.Id);
			if (article == null) throw new Exception("hata");
			_comments.DbSet.RemoveRangeRecursive(article.Comments);
			_articles.DbSet.Remove(article);
			return new NoContentResponseDto();
		}
	}
}
