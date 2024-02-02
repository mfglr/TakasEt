using Microsoft.Extensions.Primitives;
using Common.Exceptions;

namespace Common.Extentions
{
	public static class QueryCollectionExtentions
	{

		public static string? ReadString(this IEnumerable<KeyValuePair<string, StringValues>> collection,string key)
		{
			var data = collection.Where(x => x.Key == key).FirstOrDefault();
			if (data.Key == null)
				return null;
			return data.Value.ToString();
		}

		public static int? ReadInt(this IEnumerable<KeyValuePair<string, StringValues>> collection, string key)
		{
			var data = collection.Where(x => x.Key == key).FirstOrDefault();
			if (data.Key == null)
				return null;
			try
			{
				return int.Parse(data.Value.ToString());
			}
			catch (Exception e)
			{
				throw new InvalidQueryArgumentException(data.Value.ToString(), key);
			}
		}
		
		public static IReadOnlyList<int>? ReadIntList(this IEnumerable<KeyValuePair<string, StringValues>> collection, string key)
		{
			var data = collection.Where(x => x.Key == key).FirstOrDefault();
			if (data.Key == null)
				return null;
			string[] values = data.Value.ToString().Split(',');
			List<int> r = new List<int>();
			try
			{
				foreach (var value in values)
					r.Add(int.Parse(value));
				return r;
			}
			catch (Exception e)
			{
				throw new InvalidQueryArgumentException(data.Value.ToString(),key);
			}
		}

		public static IReadOnlyList<string>? ReadStringList(this IEnumerable<KeyValuePair<string, StringValues>> collection, string key)
		{
			var data = collection.Where(x => x.Key == key).FirstOrDefault();
			if (data.Key == null)
				return null;
			return data.Value.ToString().Split(',');
		}


	}
}
