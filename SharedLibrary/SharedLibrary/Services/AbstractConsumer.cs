using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SharedLibrary.Configurations;
using SharedLibrary.Events;
using System.Text;

namespace SharedLibrary.Services
{
    public abstract class AbstractConsumer<T> : BackgroundService where T : class
    {

        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        private readonly IRabbitMQOptions _options;
        private readonly string _queueName;

        public AbstractConsumer(IRabbitMQOptions options,string queueName)
        {
            _options = options;
            _queueName = queueName;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = _options.Host,
                Port = _options.Port,
                DispatchConsumersAsync = true
            };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            var exchangeName = typeof(T).Name;
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, true, false);

            _channel.QueueDeclare(_queueName, true, false, false, null);
            _channel.QueueBind(_queueName, exchangeName, string.Empty);

            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(_queueName, false, consumer);
            
            consumer.Received += async (object sender, BasicDeliverEventArgs @event) =>
            {
                var evnt = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(@event.Body.ToArray()));
                await Consume(evnt,stoppingToken);
                _channel.BasicAck(@event.DeliveryTag, false);
                Console.WriteLine("deneme");
            };
            return Task.CompletedTask;
        }

        protected abstract Task Consume(T @event, CancellationToken stoppingToken);

        public override void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            _channel.Close();
            _channel.Dispose();
            base.Dispose();
        }
    }
}
