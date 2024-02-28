using SharedLibrary.Configurations;
using SharedLibrary.Events;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;
using UserService.Domain.UserAggregate;
using UserService.Infrastructure;

namespace OnUserAccountCreated_CreateUser.WorkerService.Consumers
{
    internal class UserAccountCreatedEventConsumer : AbstractConsumer<UserAccountCreatedEvent>
    {
        private readonly AppDbContext _context;
        private readonly IntegrationEventPublisher _publisher;

        public UserAccountCreatedEventConsumer(IRabbitMQOptions options, AppDbContext context, IntegrationEventPublisher publisher) : base(options, QueueName.OnUserAccountCreated_CreateUser_Queue.Name)
        {
            _context = context;
            _publisher = publisher;
        }

        protected override async Task Consume(UserAccountCreatedEvent @event, CancellationToken stoppingToken)
        {
            var user = new User(@event.Id);
            try
            {
                await _context.AddAsync(user,stoppingToken);
                await _context.SaveChangesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _publisher.Publish(
                    new UserCreationFailedEvent(){ Id = @event.Id, Message = ex.Message }
                );
            }
        }
    }
}
