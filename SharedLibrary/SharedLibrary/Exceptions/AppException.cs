using System.Net;

namespace SharedLibrary.Exceptions
{
	public class AppException : Exception
	{
        public HttpStatusCode StatusCode { get; private set; }
        public AppException(string message,HttpStatusCode statusCode) : base(message){
            StatusCode = statusCode;
        }

    }
}
