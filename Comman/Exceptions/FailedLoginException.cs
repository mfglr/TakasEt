using System.Net;

namespace Common.Exceptions
{
	public class FailedLoginException : AppException
	{
        public FailedLoginException() : base("Login failed for user!",HttpStatusCode.Unauthorized)
        {
            
        }
    }
}
