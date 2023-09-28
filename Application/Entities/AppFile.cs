using Application.ValueObjects;

namespace Application.Entities
{
    public class AppFile : Entity
    {
        public string BlobName { get; private set; }
        public ContainerName ContainerName { get; private set; }
        public Guid? PostId { get; private  set; }
        public Post? Post { get; }
        public Guid? UserId { get; private set; }
        public User? User { get; }

        public AppFile()
        {
            
        }

        private void setOwnerId(Guid ownerId)
        {
            if(ContainerName.Equal(ContainerName.PostImage)) PostId = ownerId;
            else if(ContainerName.Equal(ContainerName.ProfileImage)) UserId = ownerId;
        }

        public AppFile(Guid ownerId,string blobName, ContainerName containerName)
        {
            BlobName = blobName;
            ContainerName = containerName;
			setOwnerId(ownerId);
		}
    }
}
