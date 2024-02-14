using SharedLibrary.Configurations;
using SharedLibrary.Helpers;
using SharedLibrary.ValueObjects;
using System.Net.Mail;

namespace SharedLibrary.Services
{
    public class MailMessageFactory
    {

        private readonly IEmailServiceSettings _emailServiceSettings;

        public MailMessageFactory(IEmailServiceSettings emailServiceSettings)
        {
            _emailServiceSettings = emailServiceSettings;
        }

        public async Task<MailMessage> CreateEmailConfirmationMailMessageAsync(string receiverEmail,string token,string userId)
        {

            string path = GetPathHelper.Run("BodiesOfMailMessages/EmailConfirmationMailMessageBody.html");
            using var bodyFile = File.OpenRead(path);
            using var streamReader = new StreamReader(bodyFile);

            var body = await streamReader.ReadToEndAsync();
            body = body.Replace("{token}", token);
            body = body.Replace("{userId}", userId);

            var message = new MailMessage()
            {
                IsBodyHtml = true,
                From = new MailAddress(_emailServiceSettings.SenderMail, _emailServiceSettings.DisplayName),
                Subject = EmailSubjects.EmailConfirmationMail.Value,
                Body = body
            };
            message.To.Add(new MailAddress(receiverEmail));
            return message;
        }

    }
}
