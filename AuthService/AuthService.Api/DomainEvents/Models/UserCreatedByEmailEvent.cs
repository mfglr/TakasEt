using AuthService.Api.Entities;
using MediatR;

namespace AuthService.Api.DomainEvents.Models
{
    public class UserCreatedByEmailEvent : INotification
    {
        public User User { get; private set; }
        public UserCreatedByEmailEvent(User user)
        {
            User = user;
        }
    }
}
