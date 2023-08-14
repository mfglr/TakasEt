using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Function
{
    public class ConfirmAccountFunction
    {
        private readonly ILogger _logger;

        public ConfirmAccountFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ConfirmAccountFunction>();
        }

        [Function("ConfirmAccountFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            
            return response;
        }
    }
}
