using System.Net;

namespace Common.Exceptions
{
	public class InValidRefreshTokenException : AppException
	{
        public InValidRefreshTokenException() : base("Invalid refresh token exception", HttpStatusCode.BadRequest)
        {
            
        }
    }
}
