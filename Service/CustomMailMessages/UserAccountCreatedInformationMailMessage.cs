using Application.Entities;
using System.Net.Mail;

namespace Service.CustomMailMessages
{
	public class UserAccountCreatedInformationMailMessage : MailMessage
	{
        public UserAccountCreatedInformationMailMessage(User user)
        {
            Subject = "Your Account Has Been Created Succesfully.";
            Body =
                $@"
                    <p>
                        Hello {user.UserName},
                        <br/>
                        <br/>
                        We are very pleased to have you among us. Please click the button to confirm your account!
                        <a href='www.google.com'>Confirm</a>
                    </p>
                ";
            IsBodyHtml = true;
            To.Add(user.Email);
        }
    }
}
