using System.Net;

namespace Application.Exceptions
{
	public class TokenNotFoundException : AppException
	{
		public TokenNotFoundException() : base("Token not found!", HttpStatusCode.Unauthorized)
		{
		}
	}
}
