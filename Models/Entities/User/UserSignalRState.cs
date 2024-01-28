namespace Models.Entities
{
	public class UserSignalRState : Entity
	{
		public string ConnectionId { get; private set; }
		public User User { get; }

		public UserSignalRState(string connectionId)
		{
			ConnectionId = connectionId;
		}

		public void Update(string connectionId)
		{
			ConnectionId = connectionId;
		}
	}
}
