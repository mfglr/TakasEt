using RabbitMQ.Client.Events;
using SharedLibrary.IntegrationEvents;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;
using SharedLibrary.Extentions;

namespace OnUserAccount_Created_SendEmailConfirmationMail.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IIntegrationEventsSubscriber _subscriber;
        private readonly IEmailService _emailService;

        public Worker(IIntegrationEventsSubscriber subscriber, IEmailService emailService)
        {
            _subscriber = subscriber;
            _emailService = emailService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.Subscribe(
                Queue.User_Created_SendEmailConfirmationMail_Queue,
                SendEmailConfirmailMailHandler
            );
            return Task.CompletedTask;
        }

        private async Task SendEmailConfirmailMailHandler(object sender, BasicDeliverEventArgs @event)
        {
            var evnt = @event.Deserialize<User_Created_SendEmailConfirmationMail_Event>();
            await _emailService.SendEmailConfirmationMail(evnt.ReceiverEmail, evnt.Token, evnt.UserId);
        }
    }
}