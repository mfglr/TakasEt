using System.Net;

namespace Application.Exceptions
{
	public class InvalidLastIdValueOfPageException : AppException
	{
		public InvalidLastIdValueOfPageException() : base("Invalid last id value of page exception!", HttpStatusCode.BadRequest)
		{
		}
	}
}
