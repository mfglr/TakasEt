using Models.ValueObjects;

namespace Models.Entities
{
	public class GroupImage : Image
	{
		public bool IsActive { get; private set; }
	
		public int GroupId { get; private set; }
		public Group Group { get;}
		
		public GroupImage() { }
		public GroupImage(string blobName,string extention,Dimension dimension) : base(ContainerName.GroupImage, blobName, extention, dimension) { }

		public void Activate() => IsActive = true;
		public void Deactivate() => IsActive = false;
	}
}
