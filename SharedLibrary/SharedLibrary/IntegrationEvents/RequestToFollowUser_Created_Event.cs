using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public class RequestToFollowUser_Created_Event : IntegrationEvent
    {
        public RequestToFollowUser_Created_Event() : base(Queue.RequestToFollowUser_Created_Queue)
        {
        }

        public Guid RequestedId { get; set; }
        public Guid RequesterId { get; set; }
    }
}
