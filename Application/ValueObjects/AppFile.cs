namespace Application.ValueObjects
{
	public class AppFile
	{
		public string BlobName { get; private set; }
		public string ContainerName { get; private set; }

		public AppFile(string blobName, string containerName)
		{
			BlobName = blobName;
			ContainerName = containerName;
		}
	}
}
