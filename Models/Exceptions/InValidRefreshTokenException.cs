using System.Net;

namespace Models.Exceptions
{
	public class InValidRefreshTokenException : AppException
	{
        public InValidRefreshTokenException() : base("Invalid refresh token exception", HttpStatusCode.BadRequest)
        {
            
        }
    }
}
