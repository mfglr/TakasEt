namespace SharedLibrary.ValueObjects
{
    public class QueueName : ValueObject
    {
        public string Name { get; private set; }
        public string RouteKey { get; private set; }

        public QueueName(string name,string routeKey)
        {
            Name = name;
            RouteKey = routeKey;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return RouteKey;
        }

        public static readonly QueueName RequestJoinToGroupCreatedQueue = new(
            "RequestJoinToGroupCreatedQueue",
            "RequestJoinToGroupCreatedQueue"
        );

        public static readonly QueueName RequestToJoinGroupApprovedQueue = new(
            "RequestToJoinGroupApprovedQueue",
            "RequestToJoinGroupApprovedQueue"
        );

        public static readonly QueueName MessageLikedQueue = new(
            "MessageLikedQueue",
            "MessageLikedQueue"
        );

        public static readonly QueueName EmailConfirmationMailsWillBeSent = new(
            "EmailConfirmationMailsWillBeSent",
            "EmailConfirmationMailsWillBeSent"
        );

        public static readonly QueueName RequestToFollowUser_Created_TooManyRejectedRequests_Queue = new(
            "RequestToFollowUser_Created_TooManyRejectedRequests_Queue",
            "RequestToFollowUser_Created_TooManyRejectedRequests_Queue"
        );

        public static readonly QueueName RequestToFollowUser_Created_Queue = new(
            "RequestToFollowUser_Created_Queue",
            "RequestToFollowUser_Created_Queue"
        );

        public static readonly QueueName User_Followed_Queue = new(
            "User_Followed_Queue",
            "User_Followed_Queue"
        );

        public static readonly QueueName UserCreated_SendEmailConfirmationMailQueue = new(
            "UserCreated_SendEmailConfirmationMailQueue",
            "UserCreated_SendEmailConfirmationMailQueue"
        );

        public static readonly QueueName UserAccountCreated_CreateUserQueue = new(
            "UserAccountCreated_CreateUserQueue",
            "UserAccountCreated_CreateUserQueue"
        );

    }
}
