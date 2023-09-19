using System.Net;

namespace Application.Exceptions
{
	public class StreamNotFoundException : AppException
	{
        public StreamNotFoundException() : base("Stream not found!",HttpStatusCode.BadRequest)
        {
            
        }
    }
}
