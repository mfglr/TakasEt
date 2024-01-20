namespace Application.Entities
{
	public class BinaryConversation : Conversation
	{
		public BinaryConversation(int user1Id,int user2Id)
		{
			_userConversations.Add(new UserConversation(user1Id, Id));
			_userConversations.Add(new UserConversation(user2Id, Id));
		}
	}
}
