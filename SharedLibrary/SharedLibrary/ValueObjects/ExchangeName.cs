using RabbitMQ.Client;

namespace SharedLibrary.ValueObjects
{
    public class ExchangeName : ValueObject
    {
        public string Name {  get; private set; }
        public string Type { get ; private set; }

        private ExchangeName(string name,string type)
        {
            Name = name;
            Type = type;
        }

        public static readonly ExchangeName UserAccountCreatedEventExchange = new("UserAccountCreatedEventExchage",ExchangeType.Fanout);
        public static readonly ExchangeName MessageLikedEventExchange = new("MessageLikedEventExchange", ExchangeType.Fanout);
        public static ExchangeName RequestToFollowUserApprovedEventExchange = new("RequestToFollowUserApprovedEventExchange", ExchangeType.Fanout);
        public static ExchangeName RequestToFollowUserCreatedEventExchange = new("RequestToFollowUserCreatedEventExchange", ExchangeType.Fanout);
        public static ExchangeName RequestToJoinGroupApprovedEventExchange = new("RequestToJoinGroupApprovedEventExchange", ExchangeType.Fanout);
        public static ExchangeName RequestToJoinToGroupCreatedEventExchange = new("RequestToJoinToGroupCreatedEventExchange", ExchangeType.Fanout);
        public static ExchangeName UserFollowedEventExchange = new("UserFollowedEventExchange", ExchangeType.Fanout);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Type;
        }

    }
}
