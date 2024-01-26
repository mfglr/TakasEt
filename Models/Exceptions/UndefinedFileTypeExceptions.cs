using System.Net;

namespace Models.Exceptions
{
	internal class UndefinedFileTypeExceptions : AppException
	{
		public UndefinedFileTypeExceptions() : base("Undefined fyle type!", HttpStatusCode.BadRequest)
		{
		}
	}
}
