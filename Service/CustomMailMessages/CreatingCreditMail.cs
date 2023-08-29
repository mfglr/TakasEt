using Application.Entities;
using Microsoft.Win32;
using Service.Extentions;
using System.Collections.Generic;
using System.Net.Mail;

namespace Service.CustomMailMessages
{
	public class CreatingCreditMail : MailMessage
	{
		public CreatingCreditMail(User user)
		{
			Dictionary<string, string> replacedValues = new Dictionary<string, string>();
			replacedValues.Add("{{username}}", user.UserName);
			this.SetBodyFromHtmlTemplate("HtmlTemplates/CreatingCreditMailTemplate.html", replacedValues);
			Subject = "Your Credit Has Been Created";
			IsBodyHtml = true;
			To.Add(user.Email);
		}
	}
}
