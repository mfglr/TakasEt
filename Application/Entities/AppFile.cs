namespace Application.Entities
{
    public class AppFile : Entity
    {
        public string BlobName { get; private set; }
        public string ContainerName { get; protected set; }
        public string Extention { get; private set; }
        

        public AppFile()
        {
            
        }

        public AppFile(string blobName,string extention)
        {
            BlobName = blobName;
            Extention = extention;
		}
    }
}
