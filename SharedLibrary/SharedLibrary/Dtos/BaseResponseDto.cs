namespace SharedLibrary.Dtos
{

	public class BaseResponseDto
	{
		public Guid Id { get; set; }
		public bool IsRemoved { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime? RemovedDate { get; set; }
		
	}
}
