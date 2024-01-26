using System.Net;

namespace Models.Exceptions
{
	public class UnauthorizedAccessException : AppException
	{
		public UnauthorizedAccessException() : base("Unauthorized Access!", HttpStatusCode.Forbidden)
		{
		}
	}
}
