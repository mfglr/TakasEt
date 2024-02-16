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

        public static readonly Queue RequestJoinToGroup_Created_Queue = new()
        {
            QueueName = "RequestJoinToGroup_Created_Queue",
            RouteKey = "RequestJoinToGroup_Created_Queue"
        };
        
        public static readonly Queue RequestToJoinGroup_Approved_Queue = new()
        {
            QueueName = "RequestToJoinGroup_Approved_Queue",
            RouteKey = "RequestToJoinGroup_Approved_Queue"
        };

        public static readonly Queue Message_Liked_Queue = new()
        {
            QueueName = "Message_Liked_Queue",
            RouteKey = "Message_Liked_Queue"
        };

        public static readonly Queue EmailConfirmationMailsWillBeSent = new()
        {
            QueueName = "EmailConfirmationMailsWillBeSent",
            RouteKey = "EmailConfirmationMailsWillBeSent"
        };

        public static readonly Queue RequesToFollowUser_Created_TooManyRejectedRequests_Queue = new()
        {
            QueueName = "RequesToFollowUser_Created_TooManyRejectedRequests_Queue",
            RouteKey = "RequesToFollowUser_Created_TooManyRejectedRequests_Queue"
        };

        public static readonly Queue RequestToFollowUser_Created_Queue = new()
        {
            QueueName = "RequestToFollowUser_Created_Queue",
            RouteKey = "RequestToFollowUser_Created_Queue"
        };

        public static readonly Queue User_Followed_Queue = new()
        {
            QueueName = "User_Followed_Queue",
            RouteKey = "User_Followed_Queue"
        };

        public static readonly Queue User_Created_SendEmailConfirmationMail_Queue = new()
        {
            QueueName = "User_Created_SendEmailConfirmationMail_Queue",
            RouteKey = "User_Created_SendEmailConfirmationMail_Queue"
        };
    }
}
