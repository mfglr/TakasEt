using Models.ValueObjects;

namespace Models.Entities
{
    public class PostImage : Image
    {

        public int PostId { get; private set; }
        public int Index { get; private set; }

        public Post Post { get; }

        public PostImage() { }

        public PostImage(string blobName, string extention, int index, Dimension dimension) : base(ContainerName.PostImage, blobName, extention, dimension)
        {
            Index = index;
        }
    }
}
