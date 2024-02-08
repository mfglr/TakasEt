using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SharedLibrary.Entities;

namespace NotificationMicroservice.SharedLibrary.Entities
{
    public class Notification<T> : IViewableByUser, IRemovable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; protected set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? UpdatedDate { get; protected set; }
        public int OwnerId { get; private set; }
        public T Content { get; private set; }
        public string Type { get; private set; }

        public Notification(int ownerId,T content)
        {
            OwnerId = ownerId;
            Content = content;
            Type = typeof(T).Name;
        }

        //IViewableByUser
        public bool IsViewed { get; private set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? ViewedDate { get; private set; }
        public void View()
        {
            ViewedDate = DateTime.Now;
            IsViewed = true;
        }

        //IRemovable
        public bool IsRemoved { get; protected set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? RemovedDate { get; protected set; }
        public virtual void Remove()
        {
            IsRemoved = true;
            RemovedDate = DateTime.Now;
        }
        public virtual void Reinsert()
        {
            IsRemoved = false;
            RemovedDate = null;
        }
    }
}
