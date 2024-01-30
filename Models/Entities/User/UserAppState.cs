namespace Models.Entities
{
	public class UserAppState : Entity
	{
		public bool IsUserInApp { get; private set; }

		public User User { get; }

		public UserAppState(bool isUserInApp)
		{
			IsUserInApp = isUserInApp;
		}
	}
}
