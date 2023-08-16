using MediatR;

namespace Application.Dtos.ConfirmEmail
{
    public class ConfirmEmailCommandRequestDto : IRequest<NoContentResponseDto>
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
