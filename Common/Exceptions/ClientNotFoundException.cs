using System.Net;

namespace Common.Exceptions
{
	public class ClientNotFoundException : AppException
	{
        public ClientNotFoundException() : base("Client not found!", HttpStatusCode.NotFound)
        {
            
        }
    }
}
