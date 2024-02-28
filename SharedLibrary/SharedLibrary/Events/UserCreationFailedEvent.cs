namespace SharedLibrary.Events
{
    public class UserCreationFailedEvent : IIntegrationEvent
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
}
