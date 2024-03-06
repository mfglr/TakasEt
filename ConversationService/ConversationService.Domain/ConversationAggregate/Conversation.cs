using ConversationService.Domain.DomainEvents;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using System.Net;

namespace ConversationService.Domain.ConversationAggregate
{
    public class Conversation : Entity<Guid>, IAggregateRoot
	{
        public Guid UserId1 { get; private set; }
        public Guid UserId2 { get; private set; }
        public DateTime DateTimeOfLastMessage { get; private set; }

        public Conversation(Guid userId1, Guid userId2)
		{
            UserId1 = userId1;
            UserId2 = userId2;
		}

        private readonly List<Message> _messages = new ();
		public IReadOnlyCollection<Message> Messages => _messages;
		public Message AddMessage(string id, Guid senderId,Guid receiverId, string content,DateTime sendDate)
		{
			var message = new Message(id,senderId, receiverId, content,sendDate);
			message.MarkAsSaved();

			_messages.Add(message);
            DateTimeOfLastMessage = DateTime.UtcNow;
            
            return message;
		}
        public Message MarkAsReceived(string messageId,Guid userId)
        {
            var message = _messages.FirstOrDefault(m => m.Id == messageId);
            
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);

            if (message.ReceiverId != userId)
                throw new AppException("No Access!", HttpStatusCode.Forbidden);

            message.MarkAsReceived();
            return message;
        }
        public Message MarkAsViewed(string messageId,Guid userId)
        {
            var message = _messages.FirstOrDefault(m => m.Id == messageId);
            
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);

            if (message.ReceiverId != userId)
                throw new AppException("No Access!", HttpStatusCode.Forbidden);

            message.MarkAsViewed();
            return message;
        }
        public Message LikeMessage(Guid userId, string messageId)
        {
            if (userId != UserId1 && userId != UserId2)
                throw new AppException("No access!", HttpStatusCode.Forbidden);

            var message = _messages.FirstOrDefault(x => x.Id == messageId);
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);
            
            message.Like(userId);
            return message;
        }
        public void MarkMessagesAsViewed(Guid userId)
        {
            var messages = _messages.Where(x => x.MessageState != MessageState.Viewed && x.SenderId != userId).ToList();

            if (messages.Any())
            {
                foreach (var message in messages)
                    message.MarkAsViewed();
                AddDomainEvent(new MessagesMarkedAsViewedDomainEvent() { Messages = messages });
            }
        }

    }
}
