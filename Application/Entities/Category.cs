namespace Application.Entities
{
    public class Category : Entity
    {
        private readonly List<Post> _posts = new List<Post>();
        
        public string Name { get; private set; }
        public string Description {  get; private set; }
        public IReadOnlyCollection<Post> Posts => _posts;

		public Category(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public void AddArticle(Post article)
        {
			_posts.Add(article);
        }

        public void RemoveArticle(Post article)
        {
			_posts.Remove(article);
        }
    }
}
