﻿using ConversationService.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace ConversationService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ISender _sender;
        public MessageController(ISender sender)
        {
            _sender = sender;
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetNewMessages(CancellationToken cancellationToken)
        {
            return await _sender.Send(new GetNewMessagesDto(), cancellationToken);
        }

        [Authorize(Roles = "user")]
        [HttpGet("{userId}")]
        public async Task<IAppResponseDto> GetMessages(Guid userId,CancellationToken cancellationToken)
        {
            return await _sender.Send(
                new GetMessagesDto(HttpContext.Request.Query){ UserId = userId},
                cancellationToken
            );
        }

        [Authorize(Roles = "user")]
        [HttpPut]
        public async Task<IAppResponseDto> MarkMessagesAsReceived(MarkMessagesAsReceivedDto request, CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }

        

        [Authorize(Roles = "user")]
        [HttpPut]
        public async Task<IAppResponseDto> MarkMessagesAsViewed(MarkMessagesAsViewedDto request, CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }
    }
}