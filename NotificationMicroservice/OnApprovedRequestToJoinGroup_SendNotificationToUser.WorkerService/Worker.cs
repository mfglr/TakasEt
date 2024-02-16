using Newtonsoft.Json;
using NotificationMicroservice.SharedLibrary.Services;
using OnApprovedRequestToJoinGroup_SendNotificationToUser.WorkerService.Contents;
using RabbitMQ.Client.Events;
using SharedLibrary.IntegrationEvents;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;
using System.Text;

namespace OnApprovedRequestToJoinGroup_SendNotificationToUser.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly NotificationService<ApprovedRequestToJoinGroupContent> _notifications;
        private readonly IIntegrationEventsSubscriber _subscriber;

        public Worker(NotificationService<ApprovedRequestToJoinGroupContent> notifications, IIntegrationEventsSubscriber subscriber)
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
                Queue.RequestToJoinGroup_Approved_Queue,
                ApprovedRequestToJoinGroupNotifications_Handler
            );
            return Task.CompletedTask;
        }

        private async Task ApprovedRequestToJoinGroupNotifications_Handler(object sender, BasicDeliverEventArgs @event)
        {
            var bytes = Encoding.UTF8.GetString(@event.Body.ToArray());
            var request = JsonConvert.DeserializeObject<RequestToJoinGroup_Approved_Event>(bytes);

            var content = new ApprovedRequestToJoinGroupContent()
            {
                GroupId = request.GroupId,
                ApproverId = request.ApproverId,
            };

            await _notifications.CreateNotificationAsync(request.IdOfUserWhoJoinedTheGroup, content);
        }

    }
}