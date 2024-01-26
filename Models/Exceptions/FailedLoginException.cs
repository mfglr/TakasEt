using System.Net;

namespace Models.Exceptions
{
	public class FailedLoginException : AppException
	{
        public FailedLoginException() : base("Login failed for user!",HttpStatusCode.Unauthorized)
        {
            
        }
    }
}
