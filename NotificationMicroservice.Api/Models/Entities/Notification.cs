using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SharedLibrary.Entities;

namespace NotificationMicroservice.Api.Models.Entities
{
    public class Notification : Entity<string>, IViewableByUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public override string Id { get; protected set; }
        public int OwnerId { get; private set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string NotificationContainerId { get; private set; }

        //IViewableByUser
        public DateTime? ViewedDate { get; private set; }
        public bool IsViewed { get; private set; }
        public void View()
        {
            ViewedDate = DateTime.Now;
            IsViewed = true;
        }
    }
}
