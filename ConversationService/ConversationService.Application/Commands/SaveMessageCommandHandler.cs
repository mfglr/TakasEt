﻿using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class SaveMessageCommandHandler : IRequestHandler<SaveMessageDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingService _blockingService;

        public SaveMessageCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor, BlockingService blockingService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _blockingService = blockingService;
        }

        public async Task<IAppResponseDto> Handle(SaveMessageDto request, CancellationToken cancellationToken)
        {

            var senderId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            await _blockingService.ThrowExceptionIfBlockerOfBlockedAsync(request.ReceiverId.ToString());

            Message message = new Message(
                request.Id,
                senderId,
                request.ReceiverId,
                request.Content,
                request.SendDate.ToDateTime()
            );

            var conversationKey = new List<Guid>() { senderId, request.ReceiverId }.OrderBy(x => x).ToList();
            var conversation = await _context
                .Conversations
                .FindAsync(conversationKey[0],conversationKey[1], cancellationToken);
            
            if(conversation == null)
            {
                conversation = new Conversation(senderId, request.ReceiverId);
                conversation.AddMessage(message);
                await _context.Conversations.AddAsync(conversation,cancellationToken);
            }
            else
                conversation.AddMessage(message);
            
            await _unitOfWork.CommitAsync(cancellationToken);
            return new AppGenericSuccessResponseDto<MessageResponseDto>(
                _mapper.Map<MessageResponseDto>(message)
                );
        }
    }
}
