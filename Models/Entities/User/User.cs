using Models.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Models.DomainEventModels;

namespace Models.Entities
{
    public class User : IdentityUser<int>, IEntity, IEntityDomainEvent, IViewable<UserUserViewing>, IRemovable, IAggregateRoot
    {
        public string? Name { get; private set; }
        public string? LastName { get; private set; }
        public string? NormalizedFullName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }
        public int NumberOfPost { get; private set; }

        public UserRefreshToken UserRefreshToken { get; }
        public UserAppState UserAppState { get; }
        public IReadOnlyCollection<Message> Messages { get; }
        public IReadOnlyCollection<ConversationUser> UserConversations { get; }
        
        public IReadOnlyCollection<UserImage> UserImages => _userImages;
        public IReadOnlyCollection<Searching> Searchings => _searchings;

		public IReadOnlyCollection<Comment> Comments { get; }
		public IReadOnlyCollection<CommentUserLiking> CommentsLiked { get; }

		
		public IReadOnlyCollection<PostUserExploring> PostsExplored { get; }
		public IReadOnlyCollection<PostUserLiking> PostsLiked { get; }

		public IReadOnlyCollection<Story> Stories { get; }
        public IReadOnlyCollection<StoryImageUserLiking> StoryImagesLiked { get; }
        public IReadOnlyCollection<StoryImageUserViewing> StoryImagesViewed { get; }

        
        
        private readonly List<UserImage> _userImages = new();
        private readonly List<Searching> _searchings = new();


        public int[] GetKey() => new[] { Id };

        public User(string email, string userName)
        {
            UserName = userName;
            Email = email;
            SetCreatedDate(DateTime.Now);
        }
        public User()
        {

        }


		public IReadOnlyCollection<UserRole> Roles => _roles;
		private readonly List<UserRole> _roles = new();


		//User signalR State
		public UserSignalRState? UserSignalRState => _userSignalRState;
        private UserSignalRState? _userSignalRState;
		public void AddUserSignalRState(string connectionId)
        {
            if(_userSignalRState == null) _userSignalRState = new UserSignalRState(connectionId);
            else _userSignalRState.Update(connectionId);
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

		public IReadOnlyCollection<Post> Posts => _posts;
		private readonly List<Post> _posts = new();
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

        public IReadOnlyCollection<Following> Followings => _followings;
		public IReadOnlyCollection<Following> Followers => _followers;
        private readonly List<Following> _followings = new();
        private readonly List<Following> _followers = new();
        public void Follow(int followerId)
        {
            _followers.Add(new Following(followerId, Id));
        }
        public void Unfollow(int followerId)
        {
            int index = _followers.FindIndex(x => x.FollowerId == followerId);
            _followings.RemoveAt(index);
		}
		public void DeleteFollower(int followerId)
        {
            var index = _followers.FindIndex(x => x.FollowerId == followerId);
            _followers.RemoveAt(index);
        }
		public bool IsFollower(int userId)
        {
            return _followers.Any(x => x.FollowerId != userId);
        }
        public bool IsFollowing(int userId)
        {
            return _followings.Any(x => x.FollowingId != userId);
        }

        //user image
        public void AddUserImage(string blobName, string extention, Dimension dimension)
        {
            //deactive user image
            var activeUserImage = _userImages.FirstOrDefault(x => x.IsActive);
            if (activeUserImage != null) activeUserImage.Deactivate();
            //add new active user image
            var userImage = new UserImage(blobName, extention, dimension);
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
        
        //IRemovable
        public bool IsRemoved { get; protected set; }
        public DateTime? RemovedDate { get; protected set; }
        public void Remove()
        {
            IsRemoved = true;
            RemovedDate = DateTime.Now;
        }

        //IDomainEvent
        private List<INotification> _domainEvents = new();
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

        //IViewable
        public IReadOnlyCollection<UserUserViewing> UsersWhoViewed => _usersWhoViewed;
		public IReadOnlyCollection<UserUserViewing> UsersViewed { get; }
		private readonly List<UserUserViewing> _usersWhoViewed = new();
		public void View(int viewerId)
        {
            _usersWhoViewed.Add(new UserUserViewing(viewerId, Id));
		}
        public bool IsViewed(int viewerId)
        {
            return _usersWhoViewed.Any(x => x.ViewerId == viewerId);
        }
    }
}
