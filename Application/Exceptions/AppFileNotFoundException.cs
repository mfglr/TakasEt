using System.Net;

namespace Application.Exceptions
{
	public class AppFileNotFoundException : AppException
	{
		public AppFileNotFoundException() : base("File not found!", HttpStatusCode.NotFound)
		{
		}
	}
}
