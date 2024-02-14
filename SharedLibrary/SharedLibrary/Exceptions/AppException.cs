using System.Net;

namespace SharedLibrary.Exceptions
{
	public class AppException : Exception
	{
        public HttpStatusCode StatusCode { get; private set; }
        public AppException(string message,HttpStatusCode statusCode) : base(message){
            StatusCode = statusCode;
        }
        public AppException(IEnumerable<string> messages,HttpStatusCode statusCode) : base(string.Join(", ", messages))
        {
            StatusCode = statusCode;
        }

    }
}
