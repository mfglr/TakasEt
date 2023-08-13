namespace Application.Dtos
{
	public class CustomResponseDto<T>
	{

		private readonly List<string> _errors;

		public T Data { get; private set; }
		public IReadOnlyCollection<string> Errors => _errors;

		public void AddError(string error)
		{
			_errors.Add(error);
		}
	
		public CustomResponseDto() {
			_errors = new List<string>();
		}

		private CustomResponseDto(T data)
		{
			Data = data;
		}

		private CustomResponseDto(List<string> errors){
			_errors = errors;
		}

		public static CustomResponseDto<T> Success(T data)
		{
			return new CustomResponseDto<T>(data);
		}

		public static CustomResponseDto<T> Success()
		{
			return new CustomResponseDto<T>();
		}

		public static CustomResponseDto<T> Fail(List<string> errors)
		{
			return new CustomResponseDto<T>(errors);
		}

    }
}
