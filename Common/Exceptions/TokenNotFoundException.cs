using System.Net;

namespace Common.Exceptions
{
	public class TokenNotFoundException : AppException
	{
		public TokenNotFoundException() : base("Token not found!", HttpStatusCode.Unauthorized)
		{
		}
	}
}
