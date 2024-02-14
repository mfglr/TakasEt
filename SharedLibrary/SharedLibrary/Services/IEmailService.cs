namespace SharedLibrary.Services
{
    public interface IEmailService
    {
        Task SendEmailConfirmationMail(string receiverEMail,string token,string userId);
    }
}
