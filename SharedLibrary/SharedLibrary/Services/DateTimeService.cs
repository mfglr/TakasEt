using Microsoft.AspNetCore.Http;
using SharedLibrary.Extentions;
using System.Collections;
using System.Reflection;

namespace SharedLibrary.Services
{
    public class DateTimeService
    {

        private readonly int _offset;
        public DateTimeService(IHttpContextAccessor contextAccessor)
        {
            _offset = contextAccessor.HttpContext.GetOffset() ?? 0;
        }

        public void ConvertDateTimesRecursive(object? instance)
        {
            if (instance == null)
                return;
            
            var type = instance.GetType();
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                var items = (IEnumerable)instance;
                foreach (var item in items)
                    ConvertDateTimesRecursive(item);
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
                        property.SetValue(instance, value.AddMinutes(-1 * _offset));
                        continue;
                    }

                    if (pType.IsValueType || pType == typeof(string))
                        continue;

                    ConvertDateTimesRecursive(pInstance);
                };
            }
        }

    }
}
