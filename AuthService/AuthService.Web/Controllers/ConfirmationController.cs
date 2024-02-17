using AuthService.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AuthService.Web.Controllers
{
    [Route("[Controller]/[Action]")]
    public class ConfirmationController : Controller
    {

        private readonly ISender _sender;

        public ConfirmationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            return View(
                await _sender.Send(
                    new ConfirmEmailDto() {
                        Token = Encoding.UTF8.GetString(Convert.FromBase64String(token)),
                        UserId = userId
                    }
                )
            );
        }
    }
}
