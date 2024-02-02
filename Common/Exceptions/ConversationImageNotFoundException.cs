using System.Net;

namespace Common.Exceptions
{
	public class ConversationImageNotFoundException : AppException
	{
		public ConversationImageNotFoundException() : base("Coversation image not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
