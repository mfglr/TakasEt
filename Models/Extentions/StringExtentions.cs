using System.Text;

namespace Models.Extentions
{
	public static class StringExtentions
	{
		private static string[] turkishChars = { "İ", "Ğ", "Ü", "Ş", "Ö", "Ç" };
		private static string[] englishChars = { "I", "G", "U", "S", "O", "C" };
		
		public static string CustomNormalize(this string input)
		{
			StringBuilder result = new StringBuilder(input.ToUpper());
			for (int i = 0; i < turkishChars.Length; i++)
				result = result.Replace(turkishChars[i], englishChars[i]);
			return result.ToString();
		}
		
	}
}
