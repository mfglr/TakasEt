using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class UserAccountCreatedEvent
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
