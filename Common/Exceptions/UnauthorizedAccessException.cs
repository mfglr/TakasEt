using System.Net;

namespace Common.Exceptions
{
	public class UnauthorizedAccessException : AppException
	{
		public UnauthorizedAccessException() : base("Unauthorized Access!", HttpStatusCode.Forbidden)
		{
		}
	}
}
