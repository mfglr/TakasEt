using Newtonsoft.Json;
using NotificationMicroservice.SharedLibrary.Services;
using RabbitMQ.Client.Events;
using RequestToJoinGroup.WorkerService.Contents;
using SharedLibrary.Messages;
using SharedLibrary.ValueObjects;
using System.Text;

namespace RequestToJoinGroup.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly NotificationSubscriber _subscriber;
        private readonly NotificationService<RequestToJoinGroupContent> _service;


        public Worker(NotificationSubscriber subscriber, NotificationService<RequestToJoinGroupContent> service)
        {
            _subscriber = subscriber;
            _service = service;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Connect();
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.Subscribe(Queue.ReqeustToJoinGroup, RequestToJoinGroupNotifications_Handler);
            return Task.CompletedTask;
        }

        private async Task RequestToJoinGroupNotifications_Handler(object sender, BasicDeliverEventArgs @event)
        {

            var bytes = Encoding.UTF8.GetString(@event.Body.ToArray());
            var request = JsonConvert.DeserializeObject<RequestedJoinToGroupEvent>(bytes);

            var content = new RequestToJoinGroupContent()
            {
                GroupId = request.GroupId,
                IdOfUserWhoWantsToJoinGroup = request.IdOfUserWhoWantsToJoinGroup,
            };
            await _service.CreateNotificationsAsync(request.AdminIds, content);

        }
    }
}