namespace SharedLibrary.Dtos
{

	public class BaseResponseDto<TId>
	{
		public TId Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}

	public class BaseResponseDto : BaseResponseDto<int>
	{

	}

}
