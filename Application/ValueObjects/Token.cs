namespace Application.ValueObjects
{
	public class Token
	{
        public string Key { get; private set; }
        public DateTime Expiration { get; private set; }

		public Token(string key, DateTime expiration)
		{
			Key = key;
			Expiration = expiration;
		}

		public bool IsValid() => DateTime.Now <= Expiration; 
    }
}
