using Application.Configurations;
using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Application.Extentions;

namespace Repository.Repositories
{
	public class ArticleRepository : Repository<Article>, IArticleRepository
	{
		private readonly RecursiveRepositoryOptions _option;
		private readonly IRecursiveRepository<Comment> _comments;
		public ArticleRepository(
			SqlContext context,
			RecursiveRepositoryOptions option,
			IRecursiveRepository<Comment> comments) : base(context)
		{
			_option = option;
			_comments = comments;
		}

		public async Task<Article> GetArticleWithCommentsById(Guid id)
		{
			return await _context.Articles
				.Include(a => a.Comments)
				.GetEntityWithRecursiveEntitiesAsync(_option,id);
		}

		public void RemoveArticlesWithComments(IReadOnlyCollection<Article> articles)
		{
			foreach (var article in articles)
				RemoveArticleWithComments(article);
		}

		public void RemoveArticleWithComments(Article article)
		{
			if(article.Comments != null) 
				_comments.RemoveRange(article.Comments);
			_context.Articles.Remove(article);
		}
	}
}
