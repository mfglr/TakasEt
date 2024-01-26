using System.Net;
using System.Text;

namespace Models.Exceptions
{
	public class ValidationException : AppException
	{
        private ValidationException(string message) : base(message,HttpStatusCode.BadRequest) { }   

        public static ValidationException Create(IEnumerable<string> errors)
        {
            return new ValidationException(string.Join("\n",errors));
        }

        public static ValidationException Create(IEnumerable<string> errors,Type requestType)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Join("\n", errors));
            builder.Append($"Request Type : {requestType.Name}\n");
            return new ValidationException(builder.ToString());
        }

    }
}
