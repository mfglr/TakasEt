using Application.Entities;

namespace Application.Configurations
{
	public class LoggedInUser
	{
        public Guid UserId { get; private set; }
        public void SetUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
