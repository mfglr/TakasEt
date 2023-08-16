using Application.Entities;
using MediatR;

namespace Application.DomainEventModels
{
	public class UserCreatedDomainEvent : INotification
	{
        public User User { get; private set; }
        
        public UserCreatedDomainEvent(User user)
        {
            User = user;
        }
    }
}
