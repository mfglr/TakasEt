﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SharedLibrary.ValueObjects;

namespace NotificationMicroservice.SharedLibrary.Services
{
    public class NotificationSubscriber : IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public NotificationSubscriber(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.BasicQos(0, 1, false);
        }

        public bool ConnectionIsOpen() => _connection != null && _connection.IsOpen;


        public void Subscribe(Queue queue,Func<object, BasicDeliverEventArgs, Task> callback)
        {
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
