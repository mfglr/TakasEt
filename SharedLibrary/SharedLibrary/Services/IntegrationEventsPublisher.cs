﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using SharedLibrary.Events;
using System.Text;

namespace SharedLibrary.Services
{
    public class IntegrationEventsPublisher : IIntegrationEventsPublisher
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        
        public IntegrationEventsPublisher(string hostName,int port)
        {
            _connectionFactory = new ConnectionFactory() { HostName = hostName, Port = port };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.CreateBasicProperties().Persistent = true;
        }

        public void Publish(IntegrationEvent @event)
        {
            _channel.BasicPublish(
                @event.ExchangeName.Name,
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
