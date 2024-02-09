using OnApprovedRequestToJoinGroup_SendNotificationToUser.WorkerService.Contents;
using Newtonsoft.Json;
using NotificationMicroservice.SharedLibrary.Services;
using RabbitMQ.Client.Events;
using SharedLibrary.ValueObjects;
using System.Text;
using SharedLibrary.Services;
using SharedLibrary.Events;

namespace OnApprovedRequestToJoinGroup_SendNotificationToUser.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly NotificationService<ApprovedRequestToJoinGroupContent> _notifications;
        private readonly NotificationSubscriber _subscriber;

        public Worker(NotificationService<ApprovedRequestToJoinGroupContent> notifications, NotificationSubscriber subscriber)
        {
            _notifications = notifications;
            _subscriber = subscriber;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {

            _subscriber.Connect();
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _subscriber.Subscribe(
                Queue.ApproveRequestToJoinGroup,
                ApprovedRequestToJoinGroupNotifications_Handler
            );
            return Task.CompletedTask;
        }

        private async Task ApprovedRequestToJoinGroupNotifications_Handler(object sender, BasicDeliverEventArgs @event)
        {
            var bytes = Encoding.UTF8.GetString(@event.Body.ToArray());
            var request = JsonConvert.DeserializeObject<ApprovedRequestToJoinGroupEvent>(bytes);

            var content = new ApprovedRequestToJoinGroupContent()
            {
                GroupId = request.GroupId,
                ApproverId = request.ApproverId,
            };

            await _notifications.CreateNotificationAsync(request.IdOfUserWhoJoinedTheGroup, content);
        }

    }
}