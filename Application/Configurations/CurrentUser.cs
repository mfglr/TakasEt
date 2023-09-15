namespace Application.Configurations
{
	public class CurrentUser
	{
        public string Id { get; private set; }
		public string UserName { get; private set; }
        public string Email { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public void Set(string id,string username,string email,DateTime expirationDate)
		{
			Id = id;
			UserName = username;
			Email = email;
			ExpirationDate = expirationDate;
		}
		public bool IsValid()
		{
			return DateTime.UtcNow <= ExpirationDate;
		}
    }
}
