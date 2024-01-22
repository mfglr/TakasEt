using Application.DomainEventModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Entities
{
	public class User : IdentityUser<int>, IEntity, IEntityDomainEvent
    {
		public string? Name { get; private set; }
		public string? LastName { get; private set; }
		public string? NormalizedFullName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }
		public int NumberOfPost {  get; private set; }

		public UserRefreshToken UserRefreshToken { get; }
		public IReadOnlyCollection<Message> Messages { get; }
		public IReadOnlyCollection<UserConversation> UserConversations { get; }
		public IReadOnlyCollection<UserRole> Roles => _roles;
		public IReadOnlyCollection<Post> Posts => _posts;
		public IReadOnlyCollection<UserImage> UserImages => _userImages;
		public IReadOnlyCollection<Comment> Comments { get; }
		public IReadOnlyCollection<UserCommentLiking> LikedComments { get; }
		public IReadOnlyCollection<UserPostLiking> LikedPosts => _likedPosts;
		public IReadOnlyCollection<Following> Followings { get; }
		public IReadOnlyCollection<Following> Followers { get; }
		public IReadOnlyCollection<Searching> Searchings => _searchings;
		public IReadOnlyCollection<UserPostExploring> UserPostExplorings { get; }

		private readonly List<UserRole> _roles = new();
		private readonly List<Post> _posts = new();
        private readonly List<UserPostLiking> _likedPosts = new();
		private readonly List<UserImage> _userImages = new();
		private readonly List<Searching> _searchings = new();

		public int[] GetKey()
		{
			return new[] { Id };
		}

		public User(string email,string userName)
        {
			UserName = userName;
			Email = email;
			SetCreatedDate(DateTime.Now);
        }

        public User()
        {
            
        }

		public void AddPost(Post post)
		{
			_posts.Add(post);
			NumberOfPost++;
		}
		public void RemovePost(Post post)
		{
			_posts.Remove(post);
		}
		public void DeletePost()
		{

		}

		//user post liking
		public void LikePost(int postId) {
			_likedPosts.Add(new UserPostLiking(Id, postId));
		}
		public void DislikePost(int postId) {
			var liking = _likedPosts.FirstOrDefault(p => p.PostId == postId && p.UserId == Id);
			_likedPosts.Remove(liking!);
		}

		//user user following
		public void followUser(int userId)
		{
			
		}

		//user image
		public void AddUserImage(string blobName, string extention)
		{

			//deactive user image
			var activeUserImage = _userImages.FirstOrDefault(x => x.IsActive);
			if (activeUserImage != null) activeUserImage.Deactivate();

			//add new active user image
			var userImage = new UserImage(Id, blobName, extention);
			userImage.Activate();
			_userImages.Add(userImage);

		}
		public void RemoveUserImage(int id)
		{
			var userImage = _userImages.FirstOrDefault(x => x.Id == id);
			userImage!.Deactivate();
			userImage!.Remove();
		}
		public void DeleteUserImage(int id)
		{
			var userImage = _userImages.FirstOrDefault(x => x.Id == id);
			_userImages.Remove(userImage!);
		}
		

		//IEntity
		public int Id { get; protected set; }
		public DateTime CreatedDate { get; protected set; }
		public DateTime? UpdatedDate { get; protected set; }
		public void SetCreatedDate(DateTime date)
		{
			CreatedDate = date;
		}
		public void SetUpdatedDate(DateTime date)
		{
			UpdatedDate = date;
		}
		

		//IRemovable
		public bool IsRemoved { get; protected set; }
		public DateTime? RemovedDate { get; protected set; }
		public void Remove()
		{
			IsRemoved = true;
			RemovedDate = DateTime.Now;
		}

		//IDomainEvent
		private List<INotification> _domainEvents = new ();
		public void AddDomainEvent(INotification domainEvent)
		{
			_domainEvents.Add(domainEvent);
		}
		public void PublishAllDomainEvents(IPublisher publisher)
		{
			_domainEvents.ForEach(
				domainEvent =>
				{
					publisher.Publish(domainEvent);
				}
			);
		}
		public void ClearAllDomainEvents()
		{
			_domainEvents.Clear();
		}
		public bool AnyDomainEvents()
		{
			return _domainEvents.Any();
		}

		
	}
}
