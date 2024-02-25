using SharedLibrary.ValueObjects;

namespace AuthService.Core.ValueObjects
{
    public class Token : ValueObject
    {
        public DateTime ExpirationDate { get; private set; }
        public string Value { get; private set; }

        public Token(DateTime expirationDate, string value)
        {
            ExpirationDate = expirationDate;
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ExpirationDate;
            yield return Value;
        }
    }
}
