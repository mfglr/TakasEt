using MediatR;

namespace Application.Dtos.SignUp
{
	public class ConfirmAccountCommandRequestDto : IRequest<NoContentResponseDto>
	{
        public string Id { get; private set; }
    }
}
