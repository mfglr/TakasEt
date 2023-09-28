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
        private readonly RecursiveRepositoryOptions _option;
        public GetCommentByIdHandler(IRepository<Comment> comments, IMapper mapper, RecursiveRepositoryOptions option)
        {
            _comments = comments;
            _mapper = mapper;
            _option = option;
        }

        public async Task<AppResponseDto> Handle(GetCommentByIdRequestDto request, CancellationToken cancellationToken)
        {
            var comment = await _comments.DbSet
                .AsNoTracking()
                .IncludeChildrenByRecursive(_option.Depth)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            return AppResponseDto.Success(
                _mapper.Map<CommentResponseDto>(comment)
                );
        }
    }
}
