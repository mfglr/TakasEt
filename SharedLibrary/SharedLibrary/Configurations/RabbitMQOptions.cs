namespace SharedLibrary.Configurations
{
    public class RabbitMQOptions : IRabbitMQOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
