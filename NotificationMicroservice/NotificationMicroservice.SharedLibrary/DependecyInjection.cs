using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NotificationMicroservice.SharedLibrary.Configurations;
using NotificationMicroservice.SharedLibrary.Services;
using SharedLibrary;
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
            var mongoDbSettings = JsonConvert.DeserializeObject<MongoDBSettings>(json)!;
            return services
                .AddSingleton<IMongoDBSettings>(mongoDbSettings)
                .AddSingleton(typeof(NotificationService<>));
        }

        public static IServiceCollection AddNotificationSharedLibrary(this IServiceCollection services)
        {
            return services
                .AddMongoDb()
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        
    }
}
