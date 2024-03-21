﻿using MediatR;

namespace ConversationService.SignalR.Dtos
{
    public class CreateMessageDto : IRequest
    {
        public string Id { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public long SendDate { get; set; }
    }
}
