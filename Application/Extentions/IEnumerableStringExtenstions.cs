using System.Text;

namespace Application.Extentions
{
	public static class IEnumerableStringExtenstions
	{
		public static string Merge(this IEnumerable<string> source,string separator)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in source){
				stringBuilder.Append(item);
				stringBuilder.Append(separator);
			}
			return stringBuilder.ToString();
		}
	}
}
