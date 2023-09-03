namespace Application.Dtos
{
	public class BaseResponseDto
	{
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
	}
}
