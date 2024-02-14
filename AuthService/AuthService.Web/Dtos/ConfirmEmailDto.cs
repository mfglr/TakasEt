using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace AuthService.Web.Dtos
{
    public class ConfirmEmailDto : IRequest<AppResponseDto>
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
