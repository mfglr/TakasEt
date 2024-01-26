using System.Net;

namespace Models.Exceptions
{
	public class UserNotFoundException : AppException
	{
        public UserNotFoundException() : base("User not found!", HttpStatusCode.NotFound)
        {
            
        }
    }
}
