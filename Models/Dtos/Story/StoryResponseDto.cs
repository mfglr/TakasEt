namespace Models.Dtos
{
	public class StoryResponseDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int NumberOfStoryImages { get; set; }
		public bool IsViewed {  get; set; }
	}
}
