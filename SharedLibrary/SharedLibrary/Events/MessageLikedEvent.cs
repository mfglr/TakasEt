using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class MessageLikedEvent : IntegrationEvent
    {
        public MessageLikedEvent() : base(ExchangeName.MessageLikedEventExchange)
        {
        }

        public int IdOfUserWhoLikedTheMessage { get; set; }
        public int IdOfMessageOwner { get; set; }
        public int MessageId { get; set; }
    }
}
