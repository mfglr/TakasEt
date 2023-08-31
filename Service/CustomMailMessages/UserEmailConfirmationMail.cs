using Application.Entities;
using Service.Extentions;
using System.Net.Mail;

namespace Service.CustomMailMessages
{
	public class UserEmailConfirmationMail : MailMessage
	{
        public UserEmailConfirmationMail(User user)
        {

            Dictionary<string,string> replacedValues = new Dictionary<string,string>();
			replacedValues.Add("{{username}}", user.UserName);
            replacedValues.Add("{{token}}", user.ConfirmationEmailToken);

            this.SetBodyFromHtmlTemplate("HtmlTemplates/UserEmailConfirmaionMailTemplate.html", replacedValues);

            Subject = "Your Account Has Been Created Succesfully.";
            
            IsBodyHtml = true;
            To.Add(user.Email);
        }
    }
}
