using System.Net;

namespace SharedLibrary.Dtos
{
    public class AppFailResponseDto : IAppResponseDto
    {
        public bool IsError { get; private set; }
        public HttpStatusCode StatusCode {get; private set;}
        private readonly List<string> _errors = new();
        public IReadOnlyCollection<string>? Errors => _errors;


        public AppFailResponseDto(string error,HttpStatusCode statusCode)
        {
            IsError = true;
            StatusCode = statusCode;
            _errors.Add(error);
        }

        public AppFailResponseDto(IEnumerable<string> errors,HttpStatusCode statusCode)
        {
            IsError = true;
            StatusCode = statusCode;
            foreach (var error in errors) _errors.Add(error);
        }
    }
}
