namespace Application.Entities
{
    public class Article : Entity
    {

        public string Title { get; private set; }
        public string Content { get; private set; }
        public string SumaryOfContent { get; private set; }
        public int NumberOfLikes { get; private set; } = 0;
        public int NumberOfViews { get; private set; } = 0;
        public DateTime PublishedDate { get; private set; }
        public IReadOnlyCollection<Comment> Comments => _comments;
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        private readonly List<Comment> _comments = new List<Comment>();

        public Article(string title, string content, string sumaryOfContent, int numberOfLikes, int numberOfViews, DateTime publishedDate)
        {
            Title = title;
            Content = content;
            SumaryOfContent = sumaryOfContent;
            NumberOfLikes = numberOfLikes;
            NumberOfViews = numberOfViews;
            PublishedDate = publishedDate;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}
