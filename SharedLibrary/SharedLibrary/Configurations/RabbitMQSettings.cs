namespace SharedLibrary.Configurations
{
    public class RabbitMQSettings : IRabbitMQSettings
    {
        public string HostName { get; set; }
        public int Port { get; set; }
    }
}
