using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class UserAccountCreatedEvent
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
