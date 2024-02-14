using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SharedLibrary.Configurations;
using SharedLibrary.Helpers;
using SharedLibrary.Services;

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
                .AddSingleton<NotificationPublisher>()
                .AddSingleton<NotificationSubscriber>();
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

    }
}
