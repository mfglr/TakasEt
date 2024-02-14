using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.ConnectionAggregate
{
    public class Connection : Entity, IAggregateRoot
	{
		public int UserId { get; private set; }
		public string ConnectionId { get; private set; }
		public bool Connected { get; private set; }

        public Connection(int userId,string connectionId)
        {
			UserId = userId;
			ConnectionId = connectionId;
		}
		
		public void UpdateConnectionId(string connectionId) => ConnectionId = connectionId;
		public void Connect() => Connected = true;
		public void Disconnect() => Connected = false;

    }
}
