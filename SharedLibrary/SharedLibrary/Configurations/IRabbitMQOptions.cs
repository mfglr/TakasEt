namespace SharedLibrary.Configurations
{
    public interface IRabbitMQOptions
    {
        string Host {  get; }
        int Port { get; }
    }
}
