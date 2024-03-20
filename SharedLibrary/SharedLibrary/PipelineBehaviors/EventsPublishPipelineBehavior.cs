using MediatR;
using SharedLibrary.UnitOfWork;

namespace SharedLibrary.PipelineBehaviors
{
    public class EventsPublishPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsPublishPipelineBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var response = await next();

            _unitOfWork.PublishIntegrationEvents();
            await _unitOfWork.PublishDomainEventsAsync(cancellationToken);

            return response;
        }
    }
}
