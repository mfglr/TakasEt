using System.Net;

namespace Common.Exceptions
{
	public class PostNotFoundException : AppException
	{
        public PostNotFoundException() : base("The post not found!",HttpStatusCode.NotFound)
        {
            
        }
    }
}
