using SharedLibrary.ValueObjects;
using System.Net.Mail;

namespace SharedLibrary.Services
{
    public class SmtpEmailService : IEmailService
    {

        private  readonly MailMessageFactory _messageFactory;
        private readonly SmtpClient _smtpClient;

        public SmtpEmailService(MailMessageFactory messageFactory, SmtpClient smtpClient)
        {
            _messageFactory = messageFactory;
            _smtpClient = smtpClient;
        }

        public async Task SendEmailConfirmationMail(string receiverEmail,string token,string userId)
        {
            var mailMessagge = await _messageFactory.CreateEmailConfirmationMailMessageAsync(
                receiverEmail,
                token,
                userId
            );
            await _smtpClient.SendMailAsync(mailMessagge);
        }
    }
}
