using System.Net;

namespace Application.Exceptions
{
	public class PostNotFoundException : AppException
	{
        public PostNotFoundException() : base("The post not found!",HttpStatusCode.NotFound)
        {
            
        }
    }
}
