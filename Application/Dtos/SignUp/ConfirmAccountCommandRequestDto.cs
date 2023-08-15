using MediatR;

namespace Application.Dtos.SignUp
{
	public class ConfirmAccountCommandRequestDto : IRequest<NoContentResponseDto>
	{
        public string UserName { get; private set; }
        public string ConfimationToken { get; private set; }

		public ConfirmAccountCommandRequestDto(string userName, string confimationToken)
		{
			UserName = userName;
			ConfimationToken = confimationToken;
		}
	}
}
