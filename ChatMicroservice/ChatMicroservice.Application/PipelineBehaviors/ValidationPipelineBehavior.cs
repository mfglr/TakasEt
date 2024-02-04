using FluentValidation;
using MediatR;

namespace ChatMicroservice.Application.PipelineBehaviors
{
	public class ValidationPipelineBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if(_validators.Any())
			{
                var result = await _validators.First().ValidateAsync(request);
				if (!result.IsValid) throw new Exception("error");
            }
			return await next();
		}
	}
}
