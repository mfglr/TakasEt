using Application.Extentions;

namespace Application.Entities
{
	public class Searching : Entity
	{

        public string Key { get; private set; }
		public string NormalizeKey { get; private set; }
        public int UserId { get; private set; }
        public User User { get; }

        public Searching(int userId, string key)
		{
			UserId = userId;
			Key = key;
			NormalizeKey = key.CustomNormalize();
		}
	}
}
