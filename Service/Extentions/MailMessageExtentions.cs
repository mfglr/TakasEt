using System.Net.Mail;

namespace Service.Extentions
{
	public static class MailMessageExtentions
	{
		public static void SetBodyFromHtmlTemplate(this MailMessage message,string path)
		{
			using(var reader = new StreamReader(path))
				message.Body = reader.ReadToEnd();
		}

		public static void SetBodyFromHtmlTemplate(this MailMessage message,string path,Dictionary<string,string> pairs) {

			string body;
			using (var reader = new StreamReader(path))
				body = reader.ReadToEnd();
			
			foreach (var pair in pairs)
				body = body.Replace(pair.Key, pair.Value);
			message.Body = body;
		}
	}
}
