using System.Net;

namespace Common.Exceptions
{
	public class UserImageNotFoundException : AppException
	{
		public UserImageNotFoundException() : base("User image not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
