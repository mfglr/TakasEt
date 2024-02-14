using RabbitMQ.Client.Events;
using SharedLibrary.Events;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;

namespace SendEmailConfirmationMail.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly AppEventsSubscriber _subscriber;
        private readonly IEmailService _emailService;

        public Worker(AppEventsSubscriber subscriber, IEmailService emailService)
        {
            _subscriber = subscriber;
            _emailService = emailService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Connect();
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.Subscribe(Queue.SendEmailConfirmationMail, SendEmailConfirmailMailHandler);
            return Task.CompletedTask;
        }

        private async Task SendEmailConfirmailMailHandler(object sender, BasicDeliverEventArgs @event)
        {
            var evnt = @event.Deserialize<SendEmailConfirmationMailEvent>();
            await _emailService.SendEmailConfirmationMail(evnt.ReceiverEmail,evnt.Token,evnt.UserId);
        }
    }
}