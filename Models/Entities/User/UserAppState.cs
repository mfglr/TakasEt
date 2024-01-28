namespace Models.Entities
{
	public class UserAppState : Entity
	{
		public bool LoginState { get; private set; }
		public bool InternetState { get; private set; }

		public User User { get;}

		public UserAppState(bool loginState, bool internetState)
		{
			LoginState = loginState;
			InternetState = internetState;
		}
	}
}
