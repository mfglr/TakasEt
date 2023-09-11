using System.Net;

namespace Application.Exceptions
{
	public class FailedLoginException : CustomException
	{
        public FailedLoginException() : base("Login failed for user!",HttpStatusCode.Unauthorized)
        {
            
        }
    }
}
