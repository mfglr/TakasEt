using Application.Entities;

namespace Application.Configurations
{
	public class LoggedInUser
	{
        public int UserId { get; private set; }
        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}
