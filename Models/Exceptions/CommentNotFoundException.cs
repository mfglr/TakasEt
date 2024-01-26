using System.Net;

namespace Models.Exceptions
{
	public class CommentNotFoundException : AppException
	{
        public CommentNotFoundException() : base("Comment not found exception",HttpStatusCode.NotFound)
        {
            
        }
    }
}
