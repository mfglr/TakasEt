using System.Net;

namespace Common.Exceptions
{
	public class StreamNotFoundException : AppException
	{
        public StreamNotFoundException() : base("Stream not found!",HttpStatusCode.BadRequest)
        {
            
        }
    }
}
