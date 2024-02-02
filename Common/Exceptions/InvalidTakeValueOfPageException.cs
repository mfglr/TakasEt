using System.Net;

namespace Common.Exceptions
{
	public class InvalidTakeValueOfPageException : AppException
	{
		public InvalidTakeValueOfPageException() : base("Invalid take value of page exception", HttpStatusCode.BadRequest)
		{
		}
	}
}
