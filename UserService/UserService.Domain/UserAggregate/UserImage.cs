using SharedLibrary.Entities;
using SharedLibrary.ValueObjects;

namespace UserService.Domain.UserAggregate
{
    public class UserImage : Image<Guid>
    {
        public UserImage() { }
        public UserImage(string blobName, string extention,int height,int width) : base(ContainerName.UserImages, blobName,extention,height,width) { }


        public bool IsActive { get; private set; }
        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
