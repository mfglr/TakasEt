using Application.DomainEventModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Entities
{

	public class User : IdentityUser<Guid>, IEntity, IEntityDomainEvent
    {
		public string? Name { get; private set; }
		public string? LastName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public DateTime? UpdatedDate { get; private set; }

		public UserRefreshToken UserRefreshToken { get; }
		public IReadOnlyCollection<UserRole> Roles { get; }
		public IReadOnlyCollection<Credit> Credits { get; }
		public IReadOnlyCollection<Post> Posts { get; }
		public IReadOnlyCollection<ProfileImage> ProfileImages { get; }
        public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserCommentLiking> LikedComments { get; }
        public IReadOnlyCollection<UserPostLiking> LikedPosts { get; }
		public IReadOnlyCollection<UserPostViewing> ViewedPosts { get; }
		public IReadOnlyCollection<UserUserFollowing> Followeds { get; }
		public IReadOnlyCollection<UserUserFollowing> Followers { get; }
        public IReadOnlyCollection<UserPostFollowing> TheUserSPostsFollowedByUsers { get; }
        public IReadOnlyCollection<UserPostFollowing> PostsFollowedByTheUser { get; }
		public User(string email,string userName)
        {
			UserName = userName;
			Email = email;
			SetCreatedDate();
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

		public void SetCreatedDate()
		{
			CreatedDate = DateTime.UtcNow;
		}
		public void SetUpdatedDate()
		{
			UpdatedDate = DateTime.UtcNow;
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
