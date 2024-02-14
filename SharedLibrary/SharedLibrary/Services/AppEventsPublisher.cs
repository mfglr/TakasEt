using Newtonsoft.Json;
using RabbitMQ.Client;
using SharedLibrary.ValueObjects;
using System.Text;

namespace SharedLibrary.Services
{
    public class AppEventsPublisher : IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        private static string ExchangeName = "AppExchange";


        public AppEventsPublisher(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            Connect();
        }

        public void Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.CreateBasicProperties().Persistent = true;

            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, true, false, null);
        }

        public void CreateQueue(Queue queue)
        {
            _channel.QueueDeclare(queue.QueueName, true, false, false, null);
            _channel.QueueBind(queue.QueueName, ExchangeName, queue.RouteKey);
        }

        public bool ConnectionIsOpen() => _connection != null && _connection.IsOpen;

        public void Publish(object message,Queue queue)
        {
            if(!ConnectionIsOpen()) throw new Exception("Connection is down");
            var bodyBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _channel.BasicPublish(ExchangeName, queue.RouteKey, null, bodyBytes);
        }


        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}
