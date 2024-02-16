using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SharedLibrary.ValueObjects;

namespace SharedLibrary.Services
{
    public class IntegrationEventsSubscriber : IIntegrationEventsSubscriber
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        private static string ExchangeName = "AppExchange";

        public IntegrationEventsSubscriber(string hostName,int port)
        {
            _connectionFactory = new ConnectionFactory() {
                HostName = hostName,
                Port = port,
                DispatchConsumersAsync = true
            };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Subscribe(Queue queue,Func<object, BasicDeliverEventArgs, Task> callback)
        {
            _channel.QueueDeclare(queue.QueueName, true, false, false, null);
            _channel.QueueBind(queue.QueueName, ExchangeName, queue.RouteKey);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(queue.QueueName,false,consumer);

            consumer.Received += (object sender, BasicDeliverEventArgs @event) =>
            {
                callback(sender, @event);
                _channel.BasicAck(@event.DeliveryTag, false);
                return Task.CompletedTask;
            };
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}
