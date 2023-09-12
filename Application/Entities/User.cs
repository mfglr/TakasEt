using Application.DomainEventModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Entities
{

    public class User : Entity
    {
        
		public string? Name { get; private set; }
        public string UserName { get; private set; }
		public string Email { get; private set; }
		public string? LastName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }
        public string ConfirmationEmailToken { get; private set; }
        public bool IsEmailConfirmed { get; private set; }
        public IReadOnlyCollection<UserRefreshToken> UserRefreshTokens { get; private set; }
		public IReadOnlyCollection<Role> Roles => _roles;
		public IReadOnlyCollection<Credit> Credits => _credits;
		public IReadOnlyCollection<Article> Articles => _articles;
        public IReadOnlyCollection<Comment> Comments { get; }

		private readonly List<Role> _roles = new List<Role>();
        private readonly List<Credit> _credits = new List<Credit>();
        private readonly List<Article> _articles = new List<Article>();
        

        public User(string email,string userName)
        {
			ConfirmationEmailToken = Guid.NewGuid().ToString();
			UserName = userName;
			Email = email;
			AddDomainEvent(new UserDomainEvent(this));
        }
        
		public void ConfirmEmail() {
			IsEmailConfirmed = true;
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

		public void AddRole(Role role)
		{
			_roles.Add(role);
		}
		
	}
}
