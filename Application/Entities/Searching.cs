namespace Application.Entities
{
	public class Searching : Entity
	{

        public string Key { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; }

        public Searching(Guid userId, string key)
		{
			UserId = userId;
			Key = key;
		}
	}
}
