using System.Net;

namespace Models.Exceptions
{
	public class TokenNotFoundException : AppException
	{
		public TokenNotFoundException() : base("Token not found!", HttpStatusCode.Unauthorized)
		{
		}
	}
}
