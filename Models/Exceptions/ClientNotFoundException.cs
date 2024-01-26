using System.Net;

namespace Models.Exceptions
{
	public class ClientNotFoundException : AppException
	{
        public ClientNotFoundException() : base("Client not found!", HttpStatusCode.NotFound)
        {
            
        }
    }
}
