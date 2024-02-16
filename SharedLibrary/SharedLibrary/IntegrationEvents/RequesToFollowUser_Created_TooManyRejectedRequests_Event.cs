using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public class RequesToFollowUser_Created_TooManyRejectedRequests_Event : IntegrationEvent
    {
        public RequesToFollowUser_Created_TooManyRejectedRequests_Event() : 
            base(Queue.RequesToFollowUser_Created_TooManyRejectedRequests_Queue)
        {
        }
        public Guid RequesterId { get; set; }
        public Guid RequestedId { get; set; }
    }
}
