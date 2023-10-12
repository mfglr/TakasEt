using MediatR;

namespace Application.Dtos.ConfirmEmail
{
    public class ConfirmEmail : IRequest<string>
    {
        public string UserName { get; private set; }
        public string EmailConfirmationToken { get; private set; }

        public ConfirmEmail(string userName, string emailConfimationToken)
        {
            UserName = userName;
            EmailConfirmationToken = emailConfimationToken;
        }
    }
}
