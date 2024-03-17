using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using System.Collections;
using System.Reflection;

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

            var data = response.GetType().GetProperty("Data")!.GetValue(response)!;
            var offset = _contextAccessor.HttpContext.GetOffset() ?? 0;
            
            ConvertDateTimes(data, offset);
            
            return response;
        }



        private void ConvertDateTimes(object? instance, int offset)
        {
            if (instance == null)
                return;
            var type = instance.GetType();
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                var items = (IEnumerable)instance;
                foreach (var item in items)
                    ConvertDateTimes(item, offset);
            }
            else
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var property in properties)
                {
                    var pType = property.PropertyType;
                    var pInstance = property.GetValue(instance);
                    if ((pType == typeof(DateTime) || pType == typeof(DateTime?)) && pInstance != null)
                    {
                        var value = (DateTime)pInstance!;
                        property.SetValue(instance, value.AddMinutes(-1 * offset));
                        continue;
                    }
                    if (pType.IsValueType || pType == typeof(string))
                        continue;
                    ConvertDateTimes(pInstance, offset);
                };
            }
        }

    }
}
