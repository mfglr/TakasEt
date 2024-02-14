﻿using FluentValidation;
using MediatR;
using SharedLibrary.Exceptions;
using System.Net;

namespace AuthService.Api.PipelineBehaviors
{
    public class AppPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public AppPipelineBehavior(IUnitOfWork unitOfWork, IEnumerable<IValidator<TRequest>> validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            //validation
            if (_validators.Any())
            {
                var result = await _validators.First().ValidateAsync(request);
                var errors = string.Join("\n", result.Errors.Select(x => x.ErrorMessage).ToList());
                if (!result.IsValid) throw new AppException(errors, HttpStatusCode.BadRequest);
            }

            //begin transaction
            await _unitOfWork.BeginTransactionAsync(cancellationToken);
            
            return await next();

        }
    }
}
