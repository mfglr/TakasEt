using Application.Dtos;
using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Pipelines
{
	public class AppPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse> where TResponse : AppResponseDto
	{

		private readonly IEnumerable<IValidator<TRequest>> _validators;
		private readonly IUnitOfWork _unitOfWork;

		public AppPipelineBehavior(IEnumerable<IValidator<TRequest>> validators, IUnitOfWork unitOfWork)
		{
			_validators = validators;
			_unitOfWork = unitOfWork;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			//Validation
			if(_validators.Any())
			{
				var validationResult = await _validators.First().ValidateAsync(request);
				if (!validationResult.IsValid)
				{
					var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
					throw Exceptions.ValidationException.Create(errorMessages, request.GetType());
				}
			}
			var response = await next();
			//Commit the changes.
			if (_unitOfWork.HasChanges())
			{
				var date = await _unitOfWork.CommitAsync(cancellationToken);
				if(response.Data is BaseResponseDto)
				{
					BaseResponseDto baseResponse = (BaseResponseDto)response.Data;
					if (baseResponse != null && baseResponse.CreatedDate == default(DateTime))
						baseResponse.CreatedDate = date;
				}
			}
			return response;
		}
	}
}
