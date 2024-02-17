namespace SharedLibrary.Services
{
    public interface IEmailService
    {
        Task SendEmailConfirmationMail(string receiverEmail, string token, string userId, CancellationToken cancellationToken = default);
    }
}
