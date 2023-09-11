using Application.Extentions;
using System.Net;
using System.Text;

namespace Application.Exceptions
{
	public class ValidationException : CustomException
	{
        private ValidationException(string message) : base(message,HttpStatusCode.BadRequest) { }   

        public static ValidationException Create(IEnumerable<string> errors)
        {
            return new ValidationException(errors.Merge("\n"));
        }

        public static ValidationException Create(IEnumerable<string> errors,Type requestType)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(errors.Merge("\n"));
            builder.Append($"Request Type : {requestType.Name}\n");
            return new ValidationException(builder.ToString());
        }

    }
}
