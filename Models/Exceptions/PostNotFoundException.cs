using System.Net;

namespace Models.Exceptions
{
	public class PostNotFoundException : AppException
	{
        public PostNotFoundException() : base("The post not found!",HttpStatusCode.NotFound)
        {
            
        }
    }
}
