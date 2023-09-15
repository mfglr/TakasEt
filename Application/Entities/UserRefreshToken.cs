using Application.ValueObjects;

namespace Application.Entities
{
    public class UserRefreshToken : Entity
	{
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Token Token { get; private set; }

        public UserRefreshToken()
        {
            
        }
        public UserRefreshToken(Guid userId,Token token)
        {
            UserId = userId;
            Token = token;
        }
        public void UpdateToken(Token token) {
            Token = token;
        }
    }
}
