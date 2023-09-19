namespace Application.Dtos
{
	public class AppResponseDto
	{

        public object? Data { get; private set; }
        public IReadOnlyCollection<string> Errors => _errors!;

        private List<string>? _errors;

		private void AddError(string error)
        {
            _errors!.Add(error);
        }

        public static AppResponseDto Success<T>(T data) where T : class
		{
            return new AppResponseDto { Data = data };
        }

        public static AppResponseDto Success()
        {
            return new AppResponseDto { Data = new NoContentResponseDto() };
        }
        
        public static AppResponseDto Fail(IEnumerable<string> errors)
		{
            var response = new AppResponseDto() { Data = null};
            response._errors = new List<string>();
            foreach (var error in errors)
                response.AddError(error);
            return response;
		}

        public static AppResponseDto Fail(string error) 
        {
            var response = new AppResponseDto() { Data = null};
            response._errors = new List<string>();
			response.AddError(error);
            return response;
        }
    }
}
