using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Application.Hubs;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Domain.MessageEntity;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.ValueObjects;
using System.Net;

namespace ChatMicroservice.Application.Commands
{
    public class SaveGroupMessageComandHandler : IRequestHandler<SaveGroupMessageDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHubContext<ChatHub> _chatHub;


        public SaveGroupMessageComandHandler(ChatDbContext context, IMapper mapper, IUnitOfWork unitOfWork, IHubContext<ChatHub> chatHub)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _chatHub = chatHub;
        }

        public async Task<AppResponseDto> Handle(SaveGroupMessageDto request, CancellationToken cancellationToken)
		{

            var group = await _context
				.Groups
				.Include(x => x.Users)
				.FirstOrDefaultAsync(x => x.Id == request.GroupId, cancellationToken);
			if (group == null) throw new AppException("Group is not found!",HttpStatusCode.NotFound);
            
			Message message = group.AddMessage(request.SenderId, request.Content);
			
			foreach (var image in request.MessageImages)
				message.AddImage(image.BlobName, image.Extention, new Dimension(image.Height, image.Width));
			await _unitOfWork.CommitAsync(cancellationToken);

            return AppResponseDto.Success(_mapper.Map<MessageResponseDto>(message));
		}
	}
}
