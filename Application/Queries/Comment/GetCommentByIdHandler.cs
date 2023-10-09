using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdRequestDto, AppResponseDto>
    {

        private readonly IRepository<Comment> _comments;
        private readonly IMapper _mapper;
        public GetCommentByIdHandler(IRepository<Comment> comments, IMapper mapper)
        {
            _comments = comments;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(GetCommentByIdRequestDto request, CancellationToken cancellationToken)
        {
            var comment = await _comments.DbSet
                .AsNoTracking()
                .IncludeChildrenByRecursive(Comment.Depth)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            return AppResponseDto.Success(
                _mapper.Map<CommentResponseDto>(comment)
                );
        }
    }
}
