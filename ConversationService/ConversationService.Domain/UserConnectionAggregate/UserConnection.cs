using ConversationService.Domain.ConversationAggregate;
using ConversationService.Domain.DomainEvents;
using ConversationService.Domain.MessageEntity;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using System.Net;

namespace ConversationService.Domain.UserConnectionAggregate
{
    public class UserConnection : Entity<Guid>,IAggregateRoot
    {

        public UserConnection(Guid id) => Id = id;

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
       
        //Conversations
        private readonly List<Conversation> _incomingConversations = new();
        public IReadOnlyCollection<Conversation> IncomingConversations => _incomingConversations;
        public IReadOnlyCollection<Conversation> OutgoingConversations { get; }
        public Message SaveMessage(Guid senderId,string content)
        {

            if (IsPrivateConnection && !_usersWhoCanSendMessageToTheUser.Any(x => x.SenderId == senderId))
                throw new AppException("You have no access!", HttpStatusCode.Forbidden);
            
            var conversation = 
                _incomingConversations.FirstOrDefault(x => x.SenderId == senderId) ?? 
                OutgoingConversations.FirstOrDefault(x => x.ReceiverId == senderId);

            if (conversation == null)
            {
                conversation = new Conversation(senderId, Id);
                _incomingConversations.Add(conversation);
                conversation.AddDomainEvent( new ConversationCreatedDomainEvent() { Conversation =  conversation } );
            }

            return conversation.AddMessage(senderId, content);

        }

        //communication
        private readonly List<Communication> _usersWhoCanSendMessageToTheUser = new ();
        public IReadOnlyCollection<Communication> UsersWhoCanSendMessageToTheUser => _usersWhoCanSendMessageToTheUser;
        private readonly List<Communication> _usersTheUserCanSendMessage = new();
        public IReadOnlyCollection<Communication> UsersTheUserCanSendMessage => _usersTheUserCanSendMessage;
        public void AddSender(Guid senderId)
        {
            _usersWhoCanSendMessageToTheUser.Add(new Communication(senderId));
        }

        public bool IsPrivateConnection { get; private set; }
        public void HideConnection() => IsPrivateConnection = true;
        public void MakeConnectionVisible() => IsPrivateConnection = false;

    }
}
