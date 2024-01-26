using System.Net;

namespace Models.Exceptions
{
	public class ConversationNotFoundException : AppException
	{
		public ConversationNotFoundException() : base("Conversation not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
