using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NotificationMicroservice.SharedLibrary.Configurations;
using NotificationMicroservice.SharedLibrary.Services;
using RabbitMQ.Client;
using System.Reflection;

namespace NotificationMicroservice.SharedLibrary
{
    public static class DependecyInjection
    {

        private static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var path = $"{Path.GetDirectoryName(asm.Location)}/mongodbsettings.json";
            using var file = File.OpenRead(path);

            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var mongoDbSettings = JsonConvert.DeserializeObject<MongoDBSettings>(json);
            return services
                .AddSingleton<IMongoDBSettings>(mongoDbSettings)
                .AddSingleton(typeof(NotificationService<>));
        }

        private static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var path = $"{Path.GetDirectoryName(asm.Location)}/rabbitmqsettings.json";
            
            using var file = File.OpenRead(path);
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var rabbitMQSettings = JsonConvert.DeserializeObject<RabbitMQSettings>(json);
            return services
                .AddSingleton<IRabbitMQSettings>(rabbitMQSettings)
                .AddSingleton(
                    sp => new ConnectionFactory() {
                        HostName = rabbitMQSettings.HostName, 
                        DispatchConsumersAsync = true 
                    }
                )
                .AddSingleton<NotificationSubscriber>();
        }

        public static IServiceCollection AddSharedWithRabbitMQ(this IServiceCollection services)
        {
            return services
                .AddRabbitMQ()
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddSharedWithMongoDb(this IServiceCollection services)
        {
            return services
                .AddMongoDb()
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            return services
                .AddRabbitMQ()
                .AddMongoDb()
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        
    }
}
