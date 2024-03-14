using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using System.Collections;

namespace SharedLibrary.PipelineBehaviors
{
    public class DateTimePipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> 
        where TResponse : IAppResponseDto
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DateTimePipelineBehavior(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            
            var response = await next();
            
            if(response.IsError || response is AppSuccessResponseDto)
                return response;

            var offset = _contextAccessor.HttpContext.GetOffset() ?? 0;

            var responseType = response.GetType();
            var dataType = responseType.GetGenericArguments()[0];
            var dataProperty = responseType.GetProperty("Data")!;
            var data = dataProperty.GetValue(response)!;

            if (typeof(IEnumerable).IsAssignableFrom(dataType))
            {
                var list = (IEnumerable)data;
                var itemType = dataType.GetGenericArguments().First();
                var properties = itemType
                    .GetProperties()
                    .Where(x => x.PropertyType == typeof(DateTime) || x.PropertyType == typeof(DateTime?))
                    .ToList();

                foreach(var item in list)
                {
                    foreach(var property in properties)
                    {
                        var date = property.GetValue(item);
                        if(date != null)
                            property.SetValue(item, ((DateTime)date).AddMinutes(-1 * offset), null);
                    }
                }
            }
            else
            {
                var properties = dataType.GetProperties();
                foreach(var property in properties)
                {
                    var date = property.GetValue(data);
                    if(date != null)
                        property.SetValue(data, ((DateTime)date).AddMinutes(-1 * offset), null);
                }
            }

            return response;

        }

        private DateTime ConvertDate(DateTime date,string timeZone)
        {
            var localDate = date.ToLocalTime();
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTime(localDate, timeZoneInfo);
        }
    }
}
