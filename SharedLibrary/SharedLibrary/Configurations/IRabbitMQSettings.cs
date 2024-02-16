namespace SharedLibrary.Configurations
{
    public interface IRabbitMQSettings
    {
        string HostName { get; }
        int Port { get; }
    }
}
