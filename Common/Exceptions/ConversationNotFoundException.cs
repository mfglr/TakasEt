using System.Net;

namespace Common.Exceptions
{
	public class ConversationNotFoundException : AppException
	{
		public ConversationNotFoundException() : base("Conversation not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
