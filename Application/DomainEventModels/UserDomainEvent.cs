using Application.Entities;
using MediatR;

namespace Application.DomainEventModels
{
	public class UserDomainEvent : INotification
	{
        public User User { get; private set; }
        
        public UserDomainEvent(User user)
        {
            User = user;
        }
    }
}
