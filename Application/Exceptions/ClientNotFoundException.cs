using System.Net;

namespace Application.Exceptions
{
	public class ClientNotFoundException : CustomException
	{
        public ClientNotFoundException() : base("Client not found!", HttpStatusCode.NotFound)
        {
            
        }
    }
}
