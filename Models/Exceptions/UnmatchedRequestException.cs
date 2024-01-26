using System.Net;

namespace Models.Exceptions
{
	public class UnmatchedRequestException : AppException
	{
        public UnmatchedRequestException(string endPoint) : base($"endpoint : {endPoint}\nUnmach Exception",HttpStatusCode.BadRequest)
        {
            
        }
    }
}
