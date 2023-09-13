using System.Net;

namespace Application.Exceptions
{
	public class CommentNotFoundException : AppException
	{
        public CommentNotFoundException() : base("Comment not found exception",HttpStatusCode.NotFound)
        {
            
        }
    }
}
