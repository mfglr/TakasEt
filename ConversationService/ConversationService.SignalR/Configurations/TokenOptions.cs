namespace ConversationService.SignalR.Configurations
{
    public class TokenOptions : ITokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }
    }
}
