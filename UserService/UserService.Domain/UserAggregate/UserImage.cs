using SharedLibrary.Entities;
using SharedLibrary.ValueObjects;

namespace UserService.Domain.UserAggregate
{
    public class UserImage : Image<Guid>
    {
        public UserImage() { }
        public UserImage(string blobName, string extention, Dimension dimension) : base(ContainerName.UserImages, blobName,extention,dimension) { }


        public bool IsActive { get; private set; }
        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
