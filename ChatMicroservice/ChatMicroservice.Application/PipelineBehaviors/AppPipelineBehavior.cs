using ChatMicroservice.Core.Interfaces;
using FluentValidation;
using MediatR;

namespace ChatMicroservice.Application.PipelineBehaviors
{
	public class AppPipelineBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
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
			//validation
			if(_validators.Any())
			{
                var result = await _validators.First().ValidateAsync(request);
				if (!result.IsValid) throw new Exception("error");
            }

			//wait for the handler 
			return await next();
			
		}
	}
}
