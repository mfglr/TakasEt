using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Test.cs.CreateDumyData
{
	public class Importer
	{

		private async Task<bool> importDataAsync<T>(StreamReader reader, DbContext context, int countOfRow) where T : class
		{
			string json = "";
			T row;
			var set = context.Set<T>();
			int i = 0;
			while (i < countOfRow && (json = reader.ReadLine()) != null)
			{
				row = JsonConvert.DeserializeObject<T>(json);
				await set.AddAsync(row);
				i++;
			}
			await context.SaveChangesAsync();
			context.ChangeTracker.Clear();
			return json != null;
		}

		public async Task importFile<T>(string path, DbContext context) where T : class
		{
			FileStream file = File.OpenRead(path);
			using (var reader = new StreamReader(file))
			{
				while (await importDataAsync<T>(reader, context, 1000)) ;
			}
		}

	}
}
