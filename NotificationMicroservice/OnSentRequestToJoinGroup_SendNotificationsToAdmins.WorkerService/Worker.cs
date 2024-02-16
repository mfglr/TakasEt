using Newtonsoft.Json;
using NotificationMicroservice.SharedLibrary.Services;
using OnSentRequestToJoinGroup_SendNotificationsToAdmins.WorkerService.Contents;
using RabbitMQ.Client.Events;
using SharedLibrary.IntegrationEvents;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;
using System.Text;

namespace OnSentRequestToJoinGroup_SendNotificationsToAdmins.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IIntegrationEventsSubscriber _subscriber;
        private readonly NotificationService<RequestToJoinGroupContent> _service;

        public Worker(IIntegrationEventsSubscriber subscriber, NotificationService<RequestToJoinGroupContent> service)
        {
            _subscriber = subscriber;
            _service = service;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.Subscribe(
                Queue.RequestJoinToGroup_Created_Queue,
                RequestToJoinGroupNotifications_Handler
            );
            return Task.CompletedTask;
        }

        private async Task RequestToJoinGroupNotifications_Handler(object sender, BasicDeliverEventArgs @event)
        {

            var bytes = Encoding.UTF8.GetString(@event.Body.ToArray());
            var request = JsonConvert.DeserializeObject<RequestToJoinToGroup_Created_Event>(bytes);

            var content = new RequestToJoinGroupContent()
            {
                GroupId = request.GroupId,
                IdOfUserWhoWantsToJoinGroup = request.IdOfUserWhoWantsToJoinGroup,
            };
            await _service.CreateNotificationsAsync(request.AdminIds, content);

        }
    }
}