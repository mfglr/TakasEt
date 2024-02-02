using System.Net;

namespace Common.Exceptions
{
	public class AppFileNotFoundException : AppException
	{
		public AppFileNotFoundException() : base("File not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
