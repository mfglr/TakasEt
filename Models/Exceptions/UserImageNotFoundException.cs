using System.Net;

namespace Models.Exceptions
{
	public class UserImageNotFoundException : AppException
	{
		public UserImageNotFoundException() : base("User image not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
