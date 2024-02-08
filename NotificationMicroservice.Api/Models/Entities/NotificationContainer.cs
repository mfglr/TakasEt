using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SharedLibrary.Entities;

namespace NotificationMicroservice.Api.Models.Entities
{
    public class NotificationContainer : Entity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public override string Id { get; protected set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
