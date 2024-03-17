using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Queries
{
    public class GetConversationsQueryHandler : IRequestHandler<GetConversationsDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetConversationsQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(GetConversationsDto request, CancellationToken cancellationToken)
        {


            //var conversations = await _context.Conversations
            //    .Where(x => x.UserId1 == loginUserId || x.UserId2 == loginUserId)
            //    .Select(x => new
            //    {
            //        Conversation = x,
            //        LastMessages = x.Messages
            //            .Select(m => new
            //            {
            //                Message = m,
            //                LastDate = loginUserId == m.SenderId ? m.SendDate : (DateTime)m.ReceivedDate!
            //            })
            //            .OrderByDescending(x => x.LastDate)
            //            .Take(20)
            //    })
            //    .ToPage(
            //        x => x.LastMessages.FirstOrDefault() == null ? x.Conversation.CreatedDate : x.LastMessages.First().LastDate, request
            //    )
            //    .ToListAsync(cancellationToken);

            //var dtos = _mapper.Map<List<Conversation>, List<ConversationResponseDto>>(
            //    conversations.Select(x => x.Conversation).ToList(),
            //    x => x.AfterMap((src, dest) =>
            //    {
            //        for (int i = 0; i < src.Count; i++)
            //            dest[i].UserId = src[i].UserId1 == loginUserId ? src[i].UserId2 : src[i].UserId1;
            //    })
            //);

            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var conversations = await _context.Conversations
                .Where(x => x.UserId1 == loginUserId || x.UserId2 == loginUserId)
                .Include(
                    x => x.Messages
                        .OrderBy(x => loginUserId == x.SenderId ? x.SendDate : (DateTime)x.ReceivedDate!)
                        .ThenBy(x => x.SendDate)
                        .Take(20)
                )
                .ToPage(
                    c => c
                        .Messages
                        .OrderByDescending(x => loginUserId == x.SenderId ? x.SendDate : (DateTime)x.ReceivedDate!)
                        .ThenByDescending(x => x.SendDate)
                        .FirstOrDefault() == null ?
                            c.CreatedDate :
                            c.Messages
                                .OrderByDescending(x => loginUserId == x.SenderId ? x.SendDate : (DateTime)x.ReceivedDate!)
                                .ThenByDescending(x => x.SendDate)
                                .Select(x => new {
                                    lastDate = loginUserId == x.SenderId ? x.SendDate : (DateTime)x.ReceivedDate!
                                })
                                .First()
                                .lastDate,
                    request
                )
                .ToListAsync(cancellationToken);


            var dtos = _mapper.Map<List<Conversation>, List<ConversationResponseDto>>(
                conversations,
                x => x.AfterMap((src, dest) =>
                {
                    for (int i = 0; i < src.Count; i++)
                        dest[i].UserId = src[i].UserId1 == loginUserId ? src[i].UserId2 : src[i].UserId1;
                })
            );

            return new AppGenericSuccessResponseDto<List<ConversationResponseDto>>(dtos);
        }
    }
}
