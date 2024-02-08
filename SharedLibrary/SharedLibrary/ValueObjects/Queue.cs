namespace SharedLibrary.ValueObjects
{
    public class Queue : ValueObject
    {
        public string QueueName { get; private set; }
        public string RouteKey { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return QueueName;
            yield return RouteKey;
        }

        public static readonly Queue ReqeustToJoinGroup = new()
        {
            QueueName = "ReqeustToJoinGroup",
            RouteKey = "reqeust_to_join_group"
        };
        
        public static readonly Queue ApproveRequestToJoinGroup = new()
        {
            QueueName = "ApproveRequestToJoinGroup",
            RouteKey = "approve_request_to_join_group"
        };

    }
}
