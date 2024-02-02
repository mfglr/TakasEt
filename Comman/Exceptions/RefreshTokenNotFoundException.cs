using System.Net;

namespace Common.Exceptions
{
	public class RefreshTokenNotFoundException : AppException
	{
        public RefreshTokenNotFoundException() : base("Refresh token is not found!",HttpStatusCode.NotFound)
        {
            
        }
    }
}
