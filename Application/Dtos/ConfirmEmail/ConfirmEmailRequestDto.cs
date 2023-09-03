using MediatR;

namespace Application.Dtos.ConfirmEmail
{
    public class ConfirmEmailRequestDto : IRequest<string>
    {
        public string UserName { get; private set; }
        public string EmailConfirmationToken { get; private set; }

        public ConfirmEmailRequestDto(string userName, string emailConfimationToken)
        {
            UserName = userName;
            EmailConfirmationToken = emailConfimationToken;
        }
    }
}
