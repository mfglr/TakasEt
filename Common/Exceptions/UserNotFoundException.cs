using System.Net;

namespace Common.Exceptions
{
	public class UserNotFoundException : AppException
	{
        public UserNotFoundException() : base("User not found!", HttpStatusCode.NotFound)
        {
            
        }
    }
}
