using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using System.Net;

namespace ConversationService.Domain.ConversationAggregate
{
    public class Conversation : Entity<Guid>, IAggregateRoot
	{
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }

        public Conversation(Guid senderId, Guid receiverId)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
		}

        private readonly List<Message> _messages = new ();
		public IReadOnlyCollection<Message> Messages => _messages;
		public Message AddMessage(Guid userId, string content)
		{
			var message = new Message(userId, content);
			message.ChangeStateToSaved();
			_messages.Add(message);
            return message;
		}
        public Message ChangeMessageStateToReceived(Guid receiverId, Guid messageId)
        {
            if(receiverId != ReceiverId)
                throw new AppException("No access!",HttpStatusCode.Forbidden);

            var message = _messages.FirstOrDefault(m => m.Id == messageId);
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);

            if (message.State == MessageState.Received)
                throw new AppException("State of the message is already received!", HttpStatusCode.BadRequest);

            message.ChangeStateToReceived();
            return message;
        }
        public Message ChangeMessageStateToViewed(Guid receiverId, Guid messageId)
        {
            if (receiverId != ReceiverId)
                throw new AppException("No access!", HttpStatusCode.Forbidden);

            var message = _messages.FirstOrDefault(m => m.Id == messageId);
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);

            if (message.State == MessageState.Viewed)
                throw new AppException("State of the message is already viewed!", HttpStatusCode.BadRequest);

            message.ChangeStateToViewed();
            return message;
        }
        public Message LikeMessage(Guid userId, Guid messageId)
        {
            if (userId != ReceiverId && userId != SenderId)
                throw new AppException("No access!", HttpStatusCode.Forbidden);

            var message = _messages.FirstOrDefault(x => x.Id == messageId);
            if (message == null)
                throw new AppException("Message was not found!", HttpStatusCode.NotFound);
            
            message.Like(userId);
            return message;
        }
	}
}
