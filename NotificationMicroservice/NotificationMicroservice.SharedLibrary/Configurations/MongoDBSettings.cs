namespace NotificationMicroservice.SharedLibrary.Configurations
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string NotificationCollectionName { get; set; }
        public string NotificationContainerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
