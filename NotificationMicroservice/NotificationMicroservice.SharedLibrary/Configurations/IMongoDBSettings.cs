namespace NotificationMicroservice.SharedLibrary.Configurations
{
    public interface IMongoDBSettings
    {
         string NotificationCollectionName { get; }
         string NotificationContainerCollectionName { get; }
         string ConnectionString { get; }
         string DatabaseName { get; }
    }
}
