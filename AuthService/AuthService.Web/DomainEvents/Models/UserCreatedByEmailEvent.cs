using AuthService.Web.Entities;
using MediatR;

namespace AuthService.Web.DomainEvents.Models
{
    internal class UserCreatedByEmailEvent : INotification
    {
        public User User { get; private set; }
        public UserCreatedByEmailEvent(User user)
        {
            User = user;
        }
    }
}
