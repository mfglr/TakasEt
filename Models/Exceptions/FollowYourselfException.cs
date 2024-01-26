using System.Net;

namespace Models.Exceptions
{
	public class FollowYourselfException : AppException
	{
		public FollowYourselfException() : base("You can't follow yourself", HttpStatusCode.BadRequest)
		{
		}
	}
}
