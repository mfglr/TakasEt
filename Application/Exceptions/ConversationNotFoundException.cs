using System.Net;

namespace Application.Exceptions
{
	public class ConversationNotFoundException : AppException
	{
		public ConversationNotFoundException() : base("Conversation not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
