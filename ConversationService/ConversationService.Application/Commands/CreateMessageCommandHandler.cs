using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingService _blockingService;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, BlockingService blockingService, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _blockingService = blockingService;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(CreateMessageDto request, CancellationToken cancellationToken)
        {
            var senderId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            await _blockingService.ThrowExceptionIfBlockerOfBlockedAsync(request.ReceiverId.ToString());

            Message message = new (
                request.Id,
                senderId,
                request.ReceiverId,
                request.Content,
                request.SendDate.ToDateTime()
            );
            if(request.Images != null)
                foreach(var image in request.Images)
                    message.AddImage(image.BlobName, image.Extention, image.Height, image.Width);
            message.MarkAsCreated();

            var conversationKey = new List<Guid>() { senderId, request.ReceiverId }
                .OrderBy(x => x)
                .ToList();

            return await CreateMessage(message, conversationKey, cancellationToken);
        }


        private async Task<IAppResponseDto> CreateMessage(Message message, List<Guid> conversationKey,CancellationToken cancellationToken)
        {
            var conversation = await _context
                .Conversations
                .FindAsync(conversationKey[0], conversationKey[1], cancellationToken);

            if (conversation == null)
            {
                conversation = new Conversation(conversationKey[0], conversationKey[1]);
                conversation.AddMessage(message);
                await _context.Conversations.AddAsync(conversation, cancellationToken);
            }
            else
                conversation.AddMessage(message);
            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.ChangeTracker.Clear();
                return await CreateMessage(message,conversationKey,cancellationToken);
            }
            catch(Exception ex)
            {
                Console.WriteLine();
            }

            return new AppGenericSuccessResponseDto<MessageResponseDto>(
                _mapper.Map<MessageResponseDto>(message)
                );
        }
    }
}
