namespace Application.Entities
{
    public class UserRefreshToken : Entity
	{
        public int UserId { get; private set; }
        public User User { get; private set; }
        public string Token { get; private set; }   
        public DateTime ExpirationDate { get; private set; }

        public UserRefreshToken(int userId,string token,DateTime expirationDate)
        {
            UserId = userId;
            Token = token;
            ExpirationDate = expirationDate;
        }

        public void UpdateToken(string token,DateTime expirationDate) {
            Token = token;
            ExpirationDate = expirationDate;
        }
    }
}
