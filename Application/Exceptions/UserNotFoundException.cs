using System.Net;

namespace Application.Exceptions
{
	public class UserNotFoundException : CustomException
	{
        public UserNotFoundException() : base("User not found!", HttpStatusCode.NotFound)
        {
            
        }
    }
}
