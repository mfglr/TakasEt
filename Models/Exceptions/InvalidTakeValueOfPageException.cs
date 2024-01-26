using System.Net;

namespace Models.Exceptions
{
	public class InvalidTakeValueOfPageException : AppException
	{
		public InvalidTakeValueOfPageException() : base("Invalid take value of page exception", HttpStatusCode.BadRequest)
		{
		}
	}
}
