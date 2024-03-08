﻿using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessagesAsReceivedDto : IRequest<IAppResponseDto>
    {
        public DateTime ReceivedDate { get; set; }
    }
}
