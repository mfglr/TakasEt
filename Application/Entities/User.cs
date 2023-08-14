using Application.DomainEvents;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Entities
{

    public class User : IdentityUser<Guid>, IEntity,IEntityDomainEvent
    {
        
		public string? Name { get; private set; }
		public string? LastName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; set; }
		public IReadOnlyCollection<Article> Articles => _articles;

		public readonly List<Article> _articles = new List<Article>();
        
		private List<INotification> _domainEvents = new List<INotification>();
		public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }



        public User(string email,string username)
        {
            UserName = username;
			Email = email;
        }

        public void ConfirmAccount() { 
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
