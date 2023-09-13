using System.Net;

namespace Application.Exceptions
{
	public class InValidRefreshTokenException : AppException
	{
        public InValidRefreshTokenException() : base("Invalid refresh token exception", HttpStatusCode.BadRequest)
        {
            
        }
    }
}
