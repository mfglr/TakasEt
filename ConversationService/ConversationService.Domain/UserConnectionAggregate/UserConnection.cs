using ConversationService.Domain.DomainEvents;
using ConversationService.Domain.MessageAggregate;
using SharedLibrary.Entities;

namespace ConversationService.Domain.UserConnectionAggregate
{
    public class UserConnection : Entity<Guid>, IAggregateRoot
    {
        public UserConnection(Guid id) => Id = id;
        public string? ConnectionId { get; private set; }
        public bool IsConnected { get; private set; }
        public void Connect(string connectionId)
        {
            IsConnected = true;
            ConnectionId = connectionId;
            AddDomainEvent(new ConnectionCreatedDomainEvent() { UserConnection = this });
        }
        public void Disconnect()
        {
            IsConnected = false;
            ConnectionId = null;
        }

        public IReadOnlyCollection<Message> MessagesReceived { get; }
    }
}
