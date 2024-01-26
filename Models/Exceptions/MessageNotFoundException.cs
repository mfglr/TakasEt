using System.Net;

namespace Models.Exceptions
{
	public class MessageNotFoundException : AppException
	{
		public MessageNotFoundException() : base("Message not found", HttpStatusCode.NotFound)
		{
		}
	}
}
