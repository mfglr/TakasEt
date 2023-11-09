using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Handler.Commands
{
	public class AddCommentHandler : IRequestHandler<AddComment, AppResponseDto>
	{

		private readonly IRepository<Comment> _comments;
		private readonly IMapper _mapper;
		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<User> _users;

		public AddCommentHandler(IRepository<Comment> comments, IMapper mapper, LoggedInUser loggedInUser, IRepository<User> users)
		{
			_comments = comments;
			_mapper = mapper;
			_loggedInUser = loggedInUser;
			_users = users;
		}

		public async Task<AppResponseDto> Handle(AddComment request, CancellationToken cancellationToken)
		{
			var comment = new Comment(request.ParentId,request.PostId, request.UserId, request.Content);
			await _comments.DbSet.AddAsync(comment,cancellationToken);
			var user = await _users.DbSet.FindAsync(_loggedInUser.UserId);
			var dto = _mapper.Map<CommentResponseDto>(comment);
			dto.UserName = user.UserName!;
			return AppResponseDto.Success(dto);
		}
	}
}
