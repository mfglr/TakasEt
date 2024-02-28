using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SharedLibrary.Configurations;
using SharedLibrary.Helpers;
using SharedLibrary.Services;
using System.Net;
using System.Net.Mail;

namespace SharedLibrary
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddSmtpEmailService(this IServiceCollection services)
        {

            var path = GetPathHelper.Run("emailServiceSettings.json");
            using var file = File.OpenRead(path);
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var emailServiceSettings = JsonConvert.DeserializeObject<EmailServiceSettings>(json);

            return services
                .AddSingleton<IEmailServiceSettings>(emailServiceSettings!)
                .AddSingleton(
                    sp => {
                        return new SmtpClient()
                        {
                            Host = emailServiceSettings!.Host,
                            Port = emailServiceSettings.Port,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(emailServiceSettings.SenderMail, emailServiceSettings.Password),
                            EnableSsl = true
                        };
                    }
                )
                .AddSingleton<MailMessageFactory>()
                .AddSingleton<IEmailService,SmtpEmailService>();
        }
    }
}
