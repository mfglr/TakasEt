using System.Net;

namespace Application.Exceptions
{
	internal class UndefinedFileTypeExceptions : AppException
	{
		public UndefinedFileTypeExceptions() : base("Undefined fyle type!", HttpStatusCode.BadRequest)
		{
		}
	}
}
