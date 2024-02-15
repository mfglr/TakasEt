﻿using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Web.Dtos
{
    internal class ConfirmEmailDto : IRequest<AppResponseDto>
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
