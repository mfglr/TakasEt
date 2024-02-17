using Newtonsoft.Json;
using NotificationMicroservice.SharedLibrary.Services;
using OnLikedMessage_SendNotificationToTheOwner.WorkerService.Contents;
using RabbitMQ.Client.Events;
using SharedLibrary.Events;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;
using System.Text;

namespace OnLikedMessage_SendNotificationToTheOwner.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly NotificationService<LikedMessageContent> _notifications;
        private readonly IIntegrationEventsSubscriber _subscriber;

        public Worker(NotificationService<LikedMessageContent> notifications, IIntegrationEventsSubscriber subscriber)
        {
            _notifications = notifications;
            _subscriber = subscriber;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.Subscribe(
                ExchangeName.MessageLikedEventExchange,
                QueueName.MessageLikedQueue,
                LikedMessageNotifications_Handler
            );
            return Task.CompletedTask;
        }

        private async Task LikedMessageNotifications_Handler(object sender, BasicDeliverEventArgs @event)
        {
            var bytes = Encoding.UTF8.GetString(@event.Body.ToArray());
            var request = JsonConvert.DeserializeObject<MessageLikedEvent>(bytes);

            var content = new LikedMessageContent()
            {
                IdOfMessageOwner = request.IdOfMessageOwner,
                MessageId = request.MessageId,
            };

            await _notifications.CreateNotificationAsync(request.IdOfUserWhoLikedTheMessage, content);
        }
    }
}