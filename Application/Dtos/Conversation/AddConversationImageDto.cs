﻿using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class AddConversationImageDto : IRequest<AppResponseDto>
	{
        public int? ConversationId { get; private set; }
		public string? Extention { get; private set; }
		public Stream? Stream { get; private set; }

        public AddConversationImageDto(IFormCollection form)
        {
			Stream = form.Files.FirstOrDefault()?.OpenReadStream();
			ConversationId = form.ReadInt("conversationId");
			Extention = form.ReadString("extention");
		}
    }
}
