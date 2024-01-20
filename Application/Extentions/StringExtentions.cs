using System.Text;

namespace Application.Extentions
{
	public static class StringExtentions
	{
		private static string[] turkishChars = { "İ", "Ğ", "Ü", "Ş", "Ö", "Ç" };
		private static string[] englishChars = { "I", "G", "U", "S", "O", "C" };
		
		public static string? CustomNormalize(this string? input)
		{
			if (input == null)
				return null;
			StringBuilder result = new StringBuilder(input.ToUpper());
			for (int i = 0; i < turkishChars.Length; i++)
				result = result.Replace(turkishChars[i], englishChars[i]);
			return result.ToString();
		}

		//public static bool IsNumeric(this string input) {
		//	if (input == "")
		//		return false;
		//	int i = 0;
		//	while (i < input.Length && char.IsDigit(input[i])) i++;
		//	return i == input.Length;
		//}
	}
}
