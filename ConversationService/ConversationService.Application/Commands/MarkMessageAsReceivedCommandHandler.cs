using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.UnitOfWork;
using System.Net;

namespace ConversationService.Application.Commands
{
    public class MarkMessageAsReceivedCommandHandler : IRequestHandler<MarkMessageAsReceivedDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MarkMessageAsReceivedCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(MarkMessageAsReceivedDto request, CancellationToken cancellationToken)
        {
            var conversation = await _context
                .Conversations
                .Include(x => x.Messages.Where(x => x.Id == request.MessageId))
                .FirstOrDefaultAsync(
                    x => 
                        x.UserId1 == request.SenderId && x.UserId2 == request.ReceiverId ||
                        x.UserId1 == request.ReceiverId && x.UserId2 == request.SenderId,
                    cancellationToken
                );
            
            if (conversation == null) 
                throw new AppException("The conversation was not found!", HttpStatusCode.NotFound);

            var message = conversation.MarkAsReceived(request.MessageId,request.ReceiverId);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new AppGenericSuccessResponseDto<MessageResponseDto>(
                _mapper.Map<MessageResponseDto>(message)
            );

        }
    }
}
