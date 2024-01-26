using System.Net;

namespace Models.Exceptions
{
	public class StreamNotFoundException : AppException
	{
        public StreamNotFoundException() : base("Stream not found!",HttpStatusCode.BadRequest)
        {
            
        }
    }
}
