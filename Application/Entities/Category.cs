
namespace Application.Entities
{
    public class Category : Entity
    {
        private readonly List<Article> _articles = new List<Article>();
        public string Name { get; private set; }
        public string Description {  get; private set; }

        public IReadOnlyCollection<Article> Atricles => _articles;

		public Category(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public void AddArticle(Article article)
        {
            _articles.Add(article);
        }

        public void RemoveArticle(Article article)
        {
            _articles.Remove(article);
        }

    }
}
