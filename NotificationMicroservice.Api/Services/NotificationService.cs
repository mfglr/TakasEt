using MongoDB.Driver;
using NotificationMicroservice.Api.Configurations;
using NotificationMicroservice.Api.Models.Entities;
using SharedLibrary.Dtos;

namespace NotificationMicroservice.Api.Services
{
    public class NotificationService
    {
        private readonly IMongoCollection<Notification> _notifications;

        public NotificationService(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _notifications = database.GetCollection<Notification>(settings.NotificationCollectionName);
        }

    }
}
