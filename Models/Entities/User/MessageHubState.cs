namespace Models.Entities
{
	public class MessageHubState : Entity
	{
		public string ConnectionId { get; private set; }
		public User User { get; }

		public MessageHubState(string connectionId)
		{
			ConnectionId = connectionId;
		}

		public void Update(string connectionId)
		{
			ConnectionId = connectionId;
		}
	}
}
