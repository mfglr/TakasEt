using System.Net;

namespace Application.Exceptions
{
	public class UserImageNotFoundException : AppException
	{
		public UserImageNotFoundException() : base("User image not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
