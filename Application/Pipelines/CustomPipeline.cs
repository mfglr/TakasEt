using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Pipelines
{
	public class CustomPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{

		private readonly IValidator<TRequest> _validator;
		private readonly IUnitOfWork _unitOfWork;

		public CustomPipeline(IValidator<TRequest> validator, IUnitOfWork unitOfWork)
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
				throw new ValidationException(errorMessages.FirstOrDefault());
			}
			var response = await next();

			//Commit the changes.

			await _unitOfWork.CommitAsync();

			return response;
		}
	}
}
