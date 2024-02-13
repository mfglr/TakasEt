namespace SharedLibrary.ValueObjects
{
    public class Token : ValueObject
    {

        public string Key { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Token(string key, DateTime expirationDate)
        {
            Key = key;
            ExpirationDate = expirationDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
            yield return ExpirationDate;
        }




    }
}
