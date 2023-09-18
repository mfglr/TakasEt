namespace Application.Dtos
{
	public class BaseResponseDto
	{
		public Guid Id { get;  set; }
		public DateTime CreatedDate { get;  set; }
		public DateTime? UpdatedDate { get;  set; }
	}
}
