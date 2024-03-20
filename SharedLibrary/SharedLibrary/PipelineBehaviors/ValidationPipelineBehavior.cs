using FluentValidation;
using MediatR;
using SharedLibrary.Exceptions;
using System.Net;

namespace SharedLibrary.PipelineBehaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var result = await _validators.First().ValidateAsync(request);
                var errors = string.Join("\n", result.Errors.Select(x => x.ErrorMessage).ToList());
                if (!result.IsValid) throw new AppException(errors,HttpStatusCode.BadRequest);
            }
            return await next();

        }
    }
}
