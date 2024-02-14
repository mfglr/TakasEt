using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Text;

namespace SharedLibrary.Extentions
{
    public static class BasicDeliverEventArgsExtentions
    {

        public static T? Deserialize<T>(this BasicDeliverEventArgs @event)
        {
            return JsonConvert.DeserializeObject<T>(
                Encoding.UTF8.GetString(@event.Body.ToArray())
            );
        }

    }
}
