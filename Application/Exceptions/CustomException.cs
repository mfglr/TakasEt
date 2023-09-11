using System.Net;

namespace Application.Exceptions
{
	public class CustomException : Exception
	{
        public HttpStatusCode StatusCode { get; private set; }
        public CustomException(string message,HttpStatusCode statusCode) : base(message){
            StatusCode = statusCode;
        }

    }
}
