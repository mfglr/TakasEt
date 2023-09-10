using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Function.Extentions
{
	public static class HttpRequestDataExtentions
	{

		public static async Task<T> ReadFromBodyAsync<T>(this HttpRequestData req) where T : class
		{
			return JsonConvert.DeserializeObject<T>( await new StreamReader(req.Body).ReadToEndAsync() );
		}

	}
}
