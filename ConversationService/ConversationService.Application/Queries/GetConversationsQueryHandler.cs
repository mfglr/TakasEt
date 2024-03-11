﻿using AutoMapper;
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

            return new AppGenericSuccessResponseDto<List<ConversationResponseDto>>(dtos);
        }
    }
}
