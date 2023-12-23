using Application.DomainEventModels;
using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Application.Entities
{
	public class User : IdentityUser<int>, IEntity, IEntityDomainEvent
    {
		public string? Name { get; private set; }
		public string? LastName { get; private set; }
		public string? NormalizedFullName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public DateTime? UpdatedDate { get; private set; }
		public int CountOfPost {  get; private set; }

		public UserRefreshToken UserRefreshToken { get; }
		public IReadOnlyCollection<UserRole> Roles => _roles;
		public IReadOnlyCollection<Post> Posts => _posts;
		public IReadOnlyCollection<UserImage> UserImages => _userImages;
		public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserCommentLiking> LikedComments { get; }
        public IReadOnlyCollection<UserPostLiking> LikedPosts => _likedPosts;
		public IReadOnlyCollection<UserUserFollowing> Followeds { get; }
		public IReadOnlyCollection<UserUserFollowing> Followers { get; }
        public IReadOnlyCollection<Searching> Searchings { get;}

		private readonly List<UserRole> _roles = new();
		private readonly List<Post> _posts = new();
        private readonly List<UserPostLiking> _likedPosts = new();
		private readonly List<UserImage> _userImages = new();

		public User(string email,string userName)
        {
			UserName = userName;
			Email = email;
			SetCreatedDate(DateTime.Now);
        }

		[JsonConstructor]
		public User(int id, string email, string userName,string name, string lastName,DateTime dateOfBirth,bool gender,DateTime createdDate,int countOfPost)
		{
			Id = id;
			Email = email;
			UserName = userName;
			Name = name;
			CountOfPost = countOfPost;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			Gender = gender;
			CreatedDate = createdDate;
			NormalizedFullName = $"{name} {lastName}".CustomNormalize();
		}

        public User()
        {
            
        }

		public void AddPost(Post post)
		{
			_posts.Add(post);
			CountOfPost++;
		}
		public void RemovePost(Post post)
		{
			_posts.Remove(post);
		}

		public void LikePost(int userId, int postId) {
			_likedPosts.Add(new UserPostLiking(userId, postId));
		}
		public void UnlikePost(UserPostLiking liking) {
			_likedPosts.Remove(liking);
		}


		//IEntity
		public void SetCreatedDate(DateTime date)
		{
			CreatedDate = date;
		}
		public void SetUpdatedDate(DateTime date)
		{
			UpdatedDate = date;
		}

		//IDomainEvent
		private List<INotification> _domainEvents = new List<INotification>();
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
