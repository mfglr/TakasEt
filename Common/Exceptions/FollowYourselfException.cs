using System.Net;

namespace Common.Exceptions
{
	public class FollowYourselfException : AppException
	{
		public FollowYourselfException() : base("You can't follow yourself", HttpStatusCode.BadRequest)
		{
		}
	}
}
