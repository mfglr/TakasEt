using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;

namespace ConversationService.Application.Queries
{
    public class GetConversationsQueryHandler : IRequestHandler<GetConversationsDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public GetConversationsQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor, IMapper mapper, UserService userService)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IAppResponseDto> Handle(GetConversationsDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            
            var conversations = await _context.Conversations
                .Where(x => x.UserId1 == loginUserId || x.UserId2 == loginUserId)
                .Include(x => x.Messages.OrderByDescending(x => x.SendDate).Take(20))
                .ToPage(x => x.Messages.OrderByDescending(x => x.SendDate).First().SendDate,request)
                .ToListAsync(cancellationToken);

            var dtos = _mapper.Map<List<Conversation>, List<ConversationResponseDto>>(
                    conversations,
                    x => x.AfterMap((src, dest) =>
                    {
                        for (int i = 0; i < src.Count; i++)
                            dest[i].UserId = src[i].UserId1 == loginUserId ? src[i].UserId2 : src[i].UserId1;
                    })
                );

            if (dtos.Any())
            {
                var ids = dtos.Select(x => x.UserId).ToList();
                var users = await _userService.GetUsersByIds(ids, cancellationToken);
                foreach (var dto in dtos)
                    dto.User = users.FirstOrDefault(x => x.Id == dto.UserId);
            }

            return new AppGenericSuccessResponseDto<List<ConversationResponseDto>>(dtos);
        }
    }
}
