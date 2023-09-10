using Application.DomainEventModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Entities
{

    public class User : IdentityUser<Guid>, IEntity,IEntityDomainEvent
    {
        
		public string? Name { get; private set; }
		public string? LastName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }
        public string ConfirmationEmailToken { get; private set; }
		public IReadOnlyCollection<UserRefreshToken> UserRefreshTokens { get; private set; }
		public IReadOnlyCollection<Credit> Credits => _credits;
		public IReadOnlyCollection<Article> Articles => _articles;
        public IReadOnlyCollection<Comment> Comments { get; }

        private readonly List<Credit> _credits = new List<Credit>();
        private readonly List<Article> _articles = new List<Article>();
        
		private List<INotification> _domainEvents = new List<INotification>();
		public Guid Id { get; private set; }
		public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

        public User(string email,string userName)
        {
			ConfirmationEmailToken = Guid.NewGuid().ToString();
			UserName = userName;
			Email = email;
			AddDomainEvent(new UserDomainEvent(this));
        }
        
		public void ConfirmEmail() { 
			EmailConfirmed = true;
		}

        public void AddArticle(Article article)
		{
			_articles.Add(article);
		}
		public void RemoveArticle(Article article)
		{
			_articles.Remove(article);
		}

		public void AddCredit(Credit credit)
		{
			_credits.Add(credit);
		}
		public void RemoveCredit(Credit credit)
		{
			_credits.Remove(credit);
		}

		public decimal CalculateTotalCredit()
		{
			decimal totalCredit = 0;
			_credits.ForEach(creadit => totalCredit += creadit.VAmount);
			return totalCredit;
		}

		//IEntity
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

		//IEntityDomainEvents
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
			var events = _domainEvents;
			var data =  _domainEvents.Any();
			return data;
		}
	}
}
