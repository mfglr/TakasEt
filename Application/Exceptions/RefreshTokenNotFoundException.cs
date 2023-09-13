using System.Net;

namespace Application.Exceptions
{
	public class RefreshTokenNotFoundException : AppException
	{
        public RefreshTokenNotFoundException() : base("Refresh token is not found!",HttpStatusCode.NotFound)
        {
            
        }
    }
}
