namespace Models.Entities
{
    public class PostUserLiking : CrossEntity
    {
        public int UserId { get; private set; }
        public int PostId { get; private set; }

        public User User { get; }
        public Post Post { get; }

        public override int[] GetKey()
        {
            return new[] { UserId, PostId };
        }

        public PostUserLiking(int userId, int postId)
        {
            UserId = userId;
            PostId = postId;
        }


    }
}
