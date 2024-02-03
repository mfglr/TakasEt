using SharedLibrary.Entities;
using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupImage : Image
	{
		public bool IsActive { get; private set; }
		public GroupImage() { }
		public GroupImage(string blobName,string extention,Dimension dimension) : base(ContainerName.GroupImages, blobName, extention, dimension) { }

		public void Activate() => IsActive = true;
		public void Deactivate() => IsActive = false;
	}
}
