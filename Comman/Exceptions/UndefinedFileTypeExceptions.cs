using System.Net;

namespace Common.Exceptions
{
	internal class UndefinedFileTypeExceptions : AppException
	{
		public UndefinedFileTypeExceptions() : base("Undefined fyle type!", HttpStatusCode.BadRequest)
		{
		}
	}
}
