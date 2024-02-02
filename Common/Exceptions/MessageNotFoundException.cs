using System.Net;

namespace Common.Exceptions
{
	public class MessageNotFoundException : AppException
	{
		public MessageNotFoundException() : base("Message not found", HttpStatusCode.NotFound)
		{
		}
	}
}
