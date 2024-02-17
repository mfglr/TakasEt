using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class UserAccountCreatedByEmailEvent : IntegrationEvent
    {
        public string Id { get; set; }

        public UserAccountCreatedByEmailEvent() : base(ExchangeName.UserAccountCreatedEventExchange)
        {
        }
    }
}
