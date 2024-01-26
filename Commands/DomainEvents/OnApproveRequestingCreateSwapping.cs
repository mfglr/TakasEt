using Application.Interfaces.Repositories;
using MediatR;
using Models.DomainEventModels;
using Models.Entities;

namespace Commands.DomainEvents
{
	public class OnApproveRequestingCreateSwapping : INotificationHandler<RequestingDomainEvent>
	{
		private readonly IRepository<Post> _posts;

		public OnApproveRequestingCreateSwapping(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public Task Handle(RequestingDomainEvent notification, CancellationToken cancellationToken)
		{
			//var requesterPostId = notification.Requesting.RequesterId;
			//var requestedPostId = notification.Requesting.RequestedId;

			//_posts
			//	.DbSet
			//	.Add(new )

			return Task.CompletedTask;
		}
	}
}
