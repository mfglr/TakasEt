using System.Net;

namespace Application.Exceptions
{
	public class CommentNotFoundException : CustomException
	{
        public CommentNotFoundException() : base("Comment not found exception",HttpStatusCode.NotFound)
        {
            
        }
    }
}
