using FluentValidation;
using MediatR;

namespace ChatMicroservice.Application.PipelineBehaviors
{
	public class AppPipelineBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public AppPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			//validation
			if(_validators.Any())
			{
                var result = await _validators.First().ValidateAsync(request);
				var errors = string.Join("\n",result.Errors.Select(x => x.ErrorMessage).ToList());
				if (!result.IsValid) throw new Exception(errors);
            }

			//wait for the handler 
			return await next();
			
		}
	}
}
