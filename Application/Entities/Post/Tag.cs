using Application.Extentions;

namespace Application.Entities
{
	public class Tag : Entity
	{
        public string Name { get; private set; }
        public string NormalizeName { get; private set; }
        public IReadOnlyCollection<PostTag> Posts { get; }

        public Tag(string name)
        {
            Name = name;
            NormalizeName = name.CustomNormalize();
        }
    }
}
