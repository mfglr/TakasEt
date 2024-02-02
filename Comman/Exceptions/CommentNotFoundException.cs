using System.Net;

namespace Common.Exceptions
{
	public class CommentNotFoundException : AppException
	{
        public CommentNotFoundException() : base("Comment not found exception",HttpStatusCode.NotFound)
        {
            
        }
    }
}
