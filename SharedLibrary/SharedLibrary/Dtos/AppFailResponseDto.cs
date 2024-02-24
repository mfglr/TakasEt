namespace SharedLibrary.Dtos
{
    public class AppFailResponseDto : IAppResponseDto
    {
        public bool IsError { get; private set; }

        private readonly List<string> _errors = new();
        public IReadOnlyCollection<string>? Errors => _errors;


        public AppFailResponseDto(string error)
        {
            IsError = true;
            _errors.Add(error);
        }

        public AppFailResponseDto(IEnumerable<string> errors)
        {
            IsError = true;
            foreach (var error in errors) _errors.Add(error);
        }
    }
}
