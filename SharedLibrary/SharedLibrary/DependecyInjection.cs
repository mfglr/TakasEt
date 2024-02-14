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

        private static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            var path = GetPathHelper.Run("rabbitmqsettings.json");
            using var file = File.OpenRead(path);
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var rabbitMQSettings = JsonConvert.DeserializeObject<RabbitMQSettings>(json);

            return services
                .AddSingleton<IRabbitMQSettings>(rabbitMQSettings)
                .AddSingleton(sp =>
                {
                    return new ConnectionFactory()
                    {
                        HostName = rabbitMQSettings.HostName,
                        DispatchConsumersAsync = true,
                    };
                }
                )
                .AddSingleton<AppEventsPublisher>()
                .AddSingleton<AppEventsSubscriber>();
        }

        public static IServiceCollection AddAppSharedLibrary(this IServiceCollection services)
        {
            return services
                .AddRabbitMQ()
                .AddSingleton(
                    sp => new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    }
                );
               
        }

        public static IServiceCollection AddJsonSerializerSettingsForCustomExceptionMiddleware(this IServiceCollection services)
        {
            return services
                .AddSingleton(
                    sp => new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    }
                );
        }

        public static IServiceCollection AddAppEventsPublisher(this IServiceCollection services)
        {
            var path = GetPathHelper.Run("rabbitmqsettings.json");
            using var file = File.OpenRead(path);
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var rabbitMQSettings = JsonConvert.DeserializeObject<RabbitMQSettings>(json);

            return services
                .AddSingleton<IRabbitMQSettings>(rabbitMQSettings)
                .AddSingleton(sp =>
                {
                    return new ConnectionFactory()
                    {
                        HostName = rabbitMQSettings.HostName,
                    };
                }
                )
                .AddSingleton<AppEventsPublisher>();
        }

        public static IServiceCollection AddAppEventsSubscriber(this IServiceCollection services)
        {
            var path = GetPathHelper.Run("rabbitmqsettings.json");
            using var file = File.OpenRead(path);
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var rabbitMQSettings = JsonConvert.DeserializeObject<RabbitMQSettings>(json);

            return services
                .AddSingleton<IRabbitMQSettings>(rabbitMQSettings)
                .AddSingleton(sp =>
                {
                    return new ConnectionFactory()
                    {
                        HostName = rabbitMQSettings.HostName,
                        DispatchConsumersAsync = true,
                    };
                }
                )
                .AddSingleton<AppEventsSubscriber>();
        }

        public static IServiceCollection AddAppEventsPublisherAndSubscriber(this IServiceCollection services)
        {
            var path = GetPathHelper.Run("rabbitmqsettings.json");
            using var file = File.OpenRead(path);
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var rabbitMQSettings = JsonConvert.DeserializeObject<RabbitMQSettings>(json);

            return services
                .AddSingleton<IRabbitMQSettings>(rabbitMQSettings)
                .AddSingleton(sp =>
                {
                    return new ConnectionFactory()
                    {
                        HostName = rabbitMQSettings.HostName,
                        DispatchConsumersAsync = true,
                    };
                }
                )
                .AddSingleton<AppEventsPublisher>()
                .AddSingleton<AppEventsSubscriber>();
        }

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
