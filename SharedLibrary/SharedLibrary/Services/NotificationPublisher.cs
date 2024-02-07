using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace SharedLibrary.Services
{
    public class NotificationPublisher : IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        private string _routeKey;

        private static string ExchangeName = "NotificationDirectExchange";


        public NotificationPublisher(ConnectionFactory connectionFactory)
        {
               _connectionFactory = connectionFactory;
        }

        public void Connect(string queueName,string routKey)
        {

            _routeKey = routKey;

            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.CreateBasicProperties().Persistent = true;

            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, true, false, null);
            _channel.QueueDeclare(queueName, true, false, false, null);
            _channel.QueueBind(queueName, ExchangeName, routKey);
        }

        public bool ConnectionIsOpen() => _connection != null && _connection.IsOpen;


        public void Publish(object message)
        {
            var bodyBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _channel.BasicPublish(ExchangeName, _routeKey, null, bodyBytes);
        }


        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}
