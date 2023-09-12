using System.Net;

namespace Application.Exceptions
{
	public class InValidRefreshTokenException : CustomException
	{
        public InValidRefreshTokenException() : base("Invalid refresh token exception", HttpStatusCode.BadRequest)
        {
            
        }
    }
}
