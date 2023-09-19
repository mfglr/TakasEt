namespace Application.Entities
{
    public class AppFile : Entity
    {
        public string BlobName { get; private set; }
        public string ContainerName { get; private set; }
        public Guid? PostId { get;  set; }
        public Post? Post { get; }
        public Guid? UserId { get;  set; }
        public User? User { get; }

        public AppFile(string blobName, string containerName)
        {
            BlobName = blobName;
            ContainerName = containerName;
        }
    }
}
