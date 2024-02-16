namespace SharedLibrary.ValueObjects
{
    public class ExchangeName : ValueObject
    {

        public string Name {  get; private set; }

        private ExchangeName(string name)
        {
            Name = name;
        }


        public static readonly ExchangeName ApprovedRequestToJoinGroupExchange =
            new("ApprovedRequestToJoinGroupExchange");
        public static readonly ExchangeName LikedMessageExchange = new("LikedMessageExchange");
        public static readonly ExchangeName RequestedJoinGroupExchange = new("RequestedJoinGroupExchange");
        public static readonly ExchangeName CreatedUserExchange = new("CreatedUserExchange");

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

    }
}
