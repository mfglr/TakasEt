using System.Net;

namespace Application.Exceptions
{
	public class ConversationImageNotFoundException : AppException
	{
		public ConversationImageNotFoundException() : base("Coversation image not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
