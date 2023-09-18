using Application.DomainEventModels;
using Application.Entities;
using Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Pipelines
{
	public class AppPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{

		private readonly IValidator<TRequest> _validator;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPublisher _publisher;

		public AppPipeline(IValidator<TRequest> validator, IUnitOfWork unitOfWork, IPublisher publisher)
		{
			_validator = validator;
			_unitOfWork = unitOfWork;
			_publisher = publisher;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			//Validation
			
			var validationResult = await _validator.ValidateAsync(request);
			if (!validationResult.IsValid)
			{
				var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
				throw Exceptions.ValidationException.Create(errorMessages,request.GetType());
			}
			var response = await next();

			//Commit the changes

			var entitiesThatHaveDomainEvents = _unitOfWork.GetEntities<IEntityDomainEvent>(x => x.Entity.AnyDomainEvents());
			foreach (var entity in entitiesThatHaveDomainEvents)
			{
				entity.PublishAllDomainEvents(_publisher);
				entity.ClearAllDomainEvents();
			}

			var createdEntity = _unitOfWork.GetEntities<IEntity>(x => x.State == EntityState.Added);
			foreach (var entity in createdEntity) entity.SetCreatedDate();

			var updatedEntity = _unitOfWork.GetEntities<IEntity>(x => x.State == EntityState.Modified);
			foreach (var entity in updatedEntity) entity.SetUpdatedDate();

			await _unitOfWork.CommitAsync();

			return response;
		}
	}
}
