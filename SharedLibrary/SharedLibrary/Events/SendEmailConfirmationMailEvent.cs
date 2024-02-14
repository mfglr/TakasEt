namespace SharedLibrary.Events
{
    public class SendEmailConfirmationMailEvent
    {
        public string ReceiverEmail { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
