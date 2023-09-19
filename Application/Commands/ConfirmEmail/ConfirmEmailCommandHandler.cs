using Application.Dtos.ConfirmEmail;
using Application.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailRequestDto, string>
	{
		private readonly UserManager<User> _userManager;

		public ConfirmEmailCommandHandler(UserManager<User> userManager)
		{
			_userManager = userManager;
		}
			
		public async Task<string> Handle(ConfirmEmailRequestDto request, CancellationToken cancellationToken)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync<User>(x => x.UserName == request.UserName, cancellationToken);
			user.ConfirmEmail();
			string result;
			using(var reader = new StreamReader("HtmlTemplates/AfterEmailConfirmationPageTemplate.html"))
				result = await reader.ReadToEndAsync();
			return result;
		}
	}
}
