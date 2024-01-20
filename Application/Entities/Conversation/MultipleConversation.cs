namespace Application.Entities
{
	public class MultipleConversation : Conversation
	{

		public void AddUser(int userId)
		{
			_userConversations.Add(new UserConversation(userId, Id));
		}
		public void RemoveUser(int userId)
		{

			_userConversations.FirstOrDefault(x => x.UserId == userId);
		}

	}
}
