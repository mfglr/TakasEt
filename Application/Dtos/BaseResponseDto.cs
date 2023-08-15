namespace Application.Dtos
{
	public class BaseResponseDto
	{
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

		public BaseResponseDto(Guid id, DateTime createdDate, DateTime? updatedDate)
		{
			Id = id;
			CreatedDate = createdDate;
			UpdatedDate = updatedDate;
		}
	}
}
