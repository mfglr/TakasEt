using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class AddCommentHandler : IRequestHandler<AddCommentDto, AppResponseDto>
    {

        private readonly IRepository<Comment> _comments;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _users;

        public AddCommentHandler(IRepository<Comment> comments, IMapper mapper, IRepository<User> users)
        {
            _comments = comments;
            _mapper = mapper;
            _users = users;
        }

        public async Task<AppResponseDto> Handle(AddCommentDto request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.ParentId, request.PostId, (int)request.UserId!, request.Content!);
            await _comments.DbSet.AddAsync(comment, cancellationToken);
            return AppResponseDto.Success(_mapper.Map<CommentResponseDto>(comment));
        }
    }
}
