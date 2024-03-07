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
			message.MarkAsCreated();

			_messages.Add(message);
            DateTimeOfLastMessage = DateTime.UtcNow;
            
            return message;
		}
        public Message MarkMessageAsReceived(string messageId,Guid userId,DateTime receivedDate)
        {
            var message = _messages.FirstOrDefault(m => m.Id == messageId);
            
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);

            if (message.ReceiverId != userId)
                throw new AppException("No Access!", HttpStatusCode.Forbidden);

            message.MarkAsReceived(receivedDate);
            return message;
        }
        public Message MarkMessageAsViewed(string messageId,Guid userId,DateTime viewedDate)
        {
            var message = _messages.FirstOrDefault(m => m.Id == messageId);
            
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);

            if (message.ReceiverId != userId)
                throw new AppException("No Access!", HttpStatusCode.Forbidden);

            message.MarkAsViewed(viewedDate);
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
        public void MarkMessagesAsViewed(Guid userId,DateTime viewedDate)
        {
            var messages = _messages.Where(x => x.MessageState != MessageState.Viewed && x.SenderId != userId).ToList();

            if (messages.Any())
            {
                foreach (var message in messages)
                    message.MarkAsViewed(viewedDate);
                AddDomainEvent(new MessagesMarkedAsViewedDomainEvent() { Messages = messages });
            }
        }
        public void MarkMessagesAsReceived(Guid userId, DateTime receivedDate)
        {
            var messages = _messages.Where(x => x.MessageState == MessageState.Created && x.SenderId != userId).ToList();

            if (messages.Any())
            {
                foreach (var message in messages)
                    message.MarkAsViewed(receivedDate);
                AddDomainEvent(new MessagesMarkedAsReceivedDomainEvent() { Messages = messages });
            }
        }

    }
}
