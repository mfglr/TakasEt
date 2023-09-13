using System.Net;

namespace Application.Exceptions
{
	public class ArticleNotFoundException : AppException
	{
        public ArticleNotFoundException() : base("Article not found!",HttpStatusCode.NotFound)
        {
            
        }
    }
}
