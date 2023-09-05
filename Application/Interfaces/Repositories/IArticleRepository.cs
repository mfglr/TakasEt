using Application.Entities;

namespace Application.Interfaces.Repositories
{
	public interface IArticleRepository : IRepository<Article>
	{
		Task<Article> GetArticleWithCommentsById(Guid id);
		void RemoveArticleWithComments(Article article);
		void RemoveArticlesWithComments(IReadOnlyCollection<Article> articles);
	}
}
