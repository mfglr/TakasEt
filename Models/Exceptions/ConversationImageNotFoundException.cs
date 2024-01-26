using System.Net;

namespace Models.Exceptions
{
	public class ConversationImageNotFoundException : AppException
	{
		public ConversationImageNotFoundException() : base("Coversation image not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
