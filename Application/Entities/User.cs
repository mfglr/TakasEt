using Application.DomainEventModels;
using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Application.Entities
{
	public class User : IdentityUser<Guid>, IEntity, IEntityDomainEvent
    {
		public string? Name { get; private set; }
		public string? LastName { get; private set; }
		public string? NormalizedFullName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public DateTime? UpdatedDate { get; private set; }
		public UserRefreshToken UserRefreshToken { get; }
		public IReadOnlyCollection<UserRole> Roles => _roles;
		public IReadOnlyCollection<Credit> Credits { get; }
		public IReadOnlyCollection<Post> Posts => _posts;
		public IReadOnlyCollection<ProfileImage> ProfileImages { get; }
        public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserCommentLiking> LikedComments { get; }
        public IReadOnlyCollection<UserPostLiking> LikedPosts { get; }
		public IReadOnlyCollection<UserPostViewing> ViewedPosts { get; }
		public IReadOnlyCollection<UserUserFollowing> Followeds { get; }
		public IReadOnlyCollection<UserUserFollowing> Followers { get; }
        public IReadOnlyCollection<UserPostFollowing> PostsFollowedByTheUser { get; }
        public IReadOnlyCollection<Searching>  Searchings{ get;}

		private readonly List<UserRole> _roles = new();
		private readonly List<Post> _posts = new();
        
		public User(string email,string userName)
        {
			UserName = userName;
			Email = email;
			SetCreatedDate(DateTime.Now);
        }

		[JsonConstructor]
		public User(Guid id, string email, string userName,string name, string lastName,DateTime dateOfBirth,bool gender,DateTime createdDate,List<UserRole> roles,List<Post> posts)
		{
			Id = id;
			Email = email;
			UserName = userName;
			Name = name;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			Gender = gender;
			CreatedDate = createdDate;
			NormalizedFullName = $"{name} {lastName}".CustomNormalize();
			foreach (var role in roles)
				_roles.Add(role);
			foreach( var post in posts)
				_posts.Add(post);
		}

        public User()
        {
            
        }
		
		public decimal CalculateTotalCredit()
		{
			decimal totalCredit = 0;
			foreach (var credit in Credits) totalCredit += credit.VAmount;
			return totalCredit;
		}

		public void SetCreatedDate(DateTime date)
		{
			CreatedDate = date;
		}
		public void SetUpdatedDate(DateTime date)
		{
			UpdatedDate = date;
		}

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
