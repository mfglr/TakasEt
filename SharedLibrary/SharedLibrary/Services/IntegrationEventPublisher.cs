using Newtonsoft.Json;
using RabbitMQ.Client;
using SharedLibrary.Configurations;
using System.Text;

namespace SharedLibrary.Services
{
    public class IntegrationEventPublisher : IDisposable
    {

        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public IntegrationEventPublisher(IRabbitMQOptions options)
        {
            _connectionFactory = new ConnectionFactory() {
                HostName = options.Host,
                Port = options.Port,
                UserName = "guest",
                Password = "guest"
            };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Publish(object @event)
        {
            var exchangeName = @event.GetType().Name;

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout,true,false);

            _channel.BasicPublish(
               exchangeName,
               string.Empty,
               null,
               Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event))
           );
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            _channel.Close();
            _channel.Dispose();
        }
    }
}
