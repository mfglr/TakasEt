namespace Application.Entities
{
	public class Comment : RecursiveEntity<Comment>
	{
		public Guid? PostId { get; private set; }
		public Post? Post { get; }
		public Guid UserId { get; private set; }
		public User User { get; private set; }
		public string Content { get; private set; }
		public IReadOnlyCollection<User> UsersWhoLiked => _usersWhoLiked;

		private readonly List<User> _usersWhoLiked = new List<User>();

		public Comment(Guid? parentId, Guid? postId, Guid userId, string content)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
		}

		public void AddUserListOfLikes(User user)
		{
			_usersWhoLiked.Add(user);
		}
		public void RemoveUser(User user) {
			_usersWhoLiked.Remove(user);
		}
	}
}
