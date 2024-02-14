using System.Text;

namespace SharedLibrary.Extentions
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
		
		public static string GetFirstSectionOfEmail(this string input)
		{
			int i = 0;
			while(input[i] != '@') i++;
			return input.Substring(0,i);
		}

	}
}
