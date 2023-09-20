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
        public string ConfirmationEmailToken { get; private set; }
        public bool IsEmailConfirmed { get; private set; }
        public UserRefreshToken UserRefreshToken { get; private set; }
		public IReadOnlyCollection<UserRole> Roles { get; }
		public IReadOnlyCollection<Credit> Credits { get; }
		public IReadOnlyCollection<Post> Posts { get; }
		public IReadOnlyCollection<AppFile> AppFiles { get; }
        public IReadOnlyCollection<Comment> Comments { get; }
		public IReadOnlyCollection<UserPostLikes> LikedPosts { get; }
		public IReadOnlyCollection<UserPostViews> ViewedPosts { get; }
		public IReadOnlyCollection<Following> Followeds { get; }
		public IReadOnlyCollection<Following> Followers { get; }
		public DateTime CreatedDate { get; private set; }
		public DateTime? UpdatedDate { get; private set; }


		private List<INotification> _domainEvents = new List<INotification>();

		public User(string email,string userName)
        {
			ConfirmationEmailToken = Guid.NewGuid().ToString();
			UserName = userName;
			Email = email;
			SetCreatedDate();
        }

        public User()
        {
            
        }
        public void ConfirmEmail() {
			IsEmailConfirmed = true;
		}
		
		public decimal CalculateTotalCredit()
		{
			decimal totalCredit = 0;
			foreach (var credit in Credits) totalCredit += credit.VAmount;
			return totalCredit;
		}

		public void SetId()
		{
			Id = Guid.NewGuid();
		}
		public void SetCreatedDate()
		{
			CreatedDate = DateTime.UtcNow;
		}
		public void SetUpdatedDate()
		{
			UpdatedDate = DateTime.UtcNow;
		}

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
