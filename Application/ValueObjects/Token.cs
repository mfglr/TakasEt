namespace Application.ValueObjects
{
    public class Token
    {
        public string Value { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Token() { }
        public Token(string value, DateTime expirationDate)
        {
            Value = value;
            ExpirationDate = expirationDate;
        }
        public bool IsValid() => DateTime.UtcNow <= ExpirationDate;
    }
}
