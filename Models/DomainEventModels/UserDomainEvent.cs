using MediatR;
using Models.Entities;

namespace Models.DomainEventModels
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
