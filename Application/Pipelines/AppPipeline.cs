using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Pipelines
{
	public class AppPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{

		private readonly IValidator<TRequest> _validator;
		private readonly IUnitOfWork _unitOfWork;

		public AppPipeline(IValidator<TRequest> validator, IUnitOfWork unitOfWork)
		{
			_validator = validator;
			_unitOfWork = unitOfWork;
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

			//Commit the changes if there are changes.
			if(_unitOfWork.HasChanges()) await _unitOfWork.CommitAsync();

			return response;
		}
	}
}
