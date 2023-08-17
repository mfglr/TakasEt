using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Dtos.ConfirmEmail
{
    public class ConfirmEmailCommandRequestDto : IRequest<string>
    {
        public string UserName { get; private set; }
        public string EmailConfirmationToken { get; private set; }

        public ConfirmEmailCommandRequestDto(string userName, string emailConfimationToken)
        {
            UserName = userName;
            EmailConfirmationToken = emailConfimationToken;
        }
    }
}
