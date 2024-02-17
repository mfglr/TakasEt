using RabbitMQ.Client.Events;
using SharedLibrary.Events;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;
using UserService.Domain.UserAggregate;
using UserService.Infrastructure;

namespace OnUserAccountCreatedByEmail_CreateUser.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IIntegrationEventsSubscriber _subscriber;
        private readonly AppDbContext _appDbContext;

        public Worker(IIntegrationEventsSubscriber subscriber, AppDbContext appDbContext)
        {
            _subscriber = subscriber;
            _appDbContext = appDbContext;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber
                .Subscribe(
                    ExchangeName.UserAccountCreatedEventExchange,
                    QueueName.UserAccountCreated_CreateUserQueue,
                    UserAccountCreated_CreateUserHandler
                );

            return Task.CompletedTask;
        }

        private async Task UserAccountCreated_CreateUserHandler(object sender, BasicDeliverEventArgs @event)
        {
            var evnt = @event.Deserialize<UserAccountCreatedByEmailEvent>();
            
            var user = new User(evnt!.Id);
            user.SetCreatedDate();

            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}