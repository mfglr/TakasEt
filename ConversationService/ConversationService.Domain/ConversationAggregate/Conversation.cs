using ConversationService.Domain.MessageEntity;
using ConversationService.Domain.UserConnectionAggregate;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using System.Net;

namespace ConversationService.Domain.ConversationAggregate
{

    /*if a conversation has been created by a user then the receiver can't create the conversation between itself and the user. it means : 
     * 
     * Conversation( senderId : 1, receiverId : 2 ) == Conversation( senderId : 2, receiverId : 1 )
	*/
    public class Conversation : Entity<Guid>, IAggregateRoot
	{
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }

        public Conversation(Guid senderId, Guid receiverId)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
		}

        //messages
        private Message GetMessageOrThrowExceptionIfIsNotExist(Guid messageId)
        {
            var message = _messages.FirstOrDefault(x => x.Id == messageId);
            return message ?? throw new Exception("error");
        }
        private readonly List<Message> _messages = new ();
		public IReadOnlyCollection<Message> Messages => _messages;
		public Message AddMessage(Guid userId, string content)
		{
			var message = new Message(userId, content);
			message.MarkAsSaved();
			_messages.Add(message);
            return message;
		}
        
	}
}
