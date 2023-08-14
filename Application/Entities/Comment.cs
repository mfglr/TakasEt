namespace Application.Entities
{
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public int NumberOfLikes { get; private set; } = 0;
    }
}
