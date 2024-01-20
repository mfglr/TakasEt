using System.Net;

namespace Application.Exceptions
{
	public class MessageNotFoundException : AppException
	{
		public MessageNotFoundException() : base("Message not found", HttpStatusCode.NotFound)
		{
		}
	}
}
