using System.Net;

namespace Application.Exceptions
{
	public class ArticleNotFoundException : CustomException
	{
        public ArticleNotFoundException() : base("Article not found!",HttpStatusCode.NotFound)
        {
            
        }
    }
}
