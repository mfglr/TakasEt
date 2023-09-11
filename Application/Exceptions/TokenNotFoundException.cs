using System.Net;

namespace Application.Exceptions
{
	public class TokenNotFoundException : CustomException
	{
		public TokenNotFoundException() : base("Token not found!", HttpStatusCode.Unauthorized)
		{
		}
	}
}
