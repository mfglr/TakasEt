using AutoMapper;
using MongoDB.Driver;
using NotificationMicroservice.SharedLibrary.Configurations;
using NotificationMicroservice.SharedLibrary.Dtos;
using NotificationMicroservice.SharedLibrary.Entities;

namespace NotificationMicroservice.SharedLibrary.Services
{
    public class NotificationService<T>
    {
        private readonly IMongoCollection<Notification<T>> _notifications;
        private readonly IMapper _mapper;


        public NotificationService(IMongoDBSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _notifications = database.GetCollection<Notification<T>>(settings.NotificationCollectionName);
            _mapper = mapper;
        }

        public async Task<NotificationResponseDto<T>> CreateNotificationAsync(int ownerId, T content, CancellationToken cancellationToken = default)
        {
            var notification = new Notification<T>(ownerId, content);
            await _notifications.InsertOneAsync(notification, cancellationToken:cancellationToken);
            return _mapper.Map<NotificationResponseDto<T>>(notification);
        }

        public async Task<List<NotificationResponseDto<T>>> CreateNotificationsAsync(List<int> ownerIds,T content,CancellationToken cancellationToken = default)
        {
            var notifications = ownerIds.Select(ownerId => new Notification<T>(ownerId, content));
            await _notifications.InsertManyAsync(notifications, cancellationToken: cancellationToken);
            return _mapper.Map<List<NotificationResponseDto<T>>>(notifications);
        }
    }
}
