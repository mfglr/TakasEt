using System.Net;

namespace Application.Exceptions
{
	public class ClientNotFoundException : AppException
	{
        public ClientNotFoundException() : base("Client not found!", HttpStatusCode.NotFound)
        {
            
        }
    }
}
