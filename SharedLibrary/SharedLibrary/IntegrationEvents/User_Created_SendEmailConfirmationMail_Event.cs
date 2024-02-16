using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public class User_Created_SendEmailConfirmationMail_Event : IntegrationEvent
    {
        public User_Created_SendEmailConfirmationMail_Event() : base(Queue.User_Created_SendEmailConfirmationMail_Queue)
        {
        }
        public string ReceiverEmail { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
