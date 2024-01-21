using Application.Extentions;

namespace Application.Entities
{
	public class Message : Entity
	{
		public int Id { get; private set; }
		public int UserId { get; private set; }
		public int ConversationId { get; private set; }
        public string Content {  get; private set; }
        public string NormalizeContent {  get; private set; }
		public DateTime ArrivalDate { get; private set; }
		public DateTime ViewingDate { get; private set; }

		public User User { get; }
		public Conversation Conversation { get; }

		public override int[] GetKey()
		{
			return new[] { Id };
		}

		public Message(int userId,string content)
		{
			UserId = userId;
			Content = content;
			NormalizeContent = content.CustomNormalize()!;
		}

		public void Update(string content)
		{
			Content = content;
		}

		public void ViewMassage()
		{
			ViewingDate = DateTime.Now;
		}

		public void ArrivaMessage()
		{
			ArrivalDate = DateTime.Now;
		}

	}
}
