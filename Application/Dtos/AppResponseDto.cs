namespace Application.Dtos
{
	public class AppResponseDto<T> where T : class
	{

        public T Data { get; private set; }
        public IReadOnlyCollection<string> Errors => _errors;

        private readonly List<string> _errors = new List<string>();

		private void AddError(string error)
        {
            _errors.Add(error);
        }

        public static AppResponseDto<T> Success(T data)
        {
            return new AppResponseDto<T> { Data = data};
        }

        public static AppResponseDto<T> Fail(IEnumerable<string> errors)
        {
            var response = new AppResponseDto<T>() {};
            foreach (var error in errors)
            {
                response.AddError(error);
			}
            return response;
		}

        public static AppResponseDto<T> Fail(string error) 
        {
            var response = new AppResponseDto<T>() {};
            response.AddError(error);
            return response;
        }
    }
}
