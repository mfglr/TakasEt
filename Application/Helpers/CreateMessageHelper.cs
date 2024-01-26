namespace Application.Helpers
{
	public class CreateMessageHelper
	{

		public static string RunHelper(string dto, string property, string message)
		{
			return $"{{\"Error\" : {{\"dto\" : \"{dto}\", \"property\" : \"{property}\", \"message\" : \"{message}\" }} }}";
		}
	}
}
