using ConversationService.Domain.ConversationAggregate;
using SharedLibrary.Entities;

namespace ConversationService.Domain.UserConnectionAggregate
{
    public class UserConnection : Entity<Guid>, IAggregateRoot
    {
        public string? ConnectionId { get; private set; }
        public bool IsConnected { get; private set; }
        public void Connect(string connectionId)
        {
            IsConnected = true;
            ConnectionId = connectionId;
        }
        public void Disconnect()
        {
            IsConnected = false;
            ConnectionId = null;
        }

        public UserConnection(Guid id) => Id = id;

        public IReadOnlyCollection<Message> Messages { get; }
    }
}
