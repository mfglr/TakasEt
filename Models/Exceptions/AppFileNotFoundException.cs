using System.Net;

namespace Models.Exceptions
{
	public class AppFileNotFoundException : AppException
	{
		public AppFileNotFoundException() : base("File not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
