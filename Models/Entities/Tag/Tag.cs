using Common.Extentions;

namespace Models.Entities
{
    public class Tag : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string NormalizeName { get; private set; }
        public IReadOnlyCollection<PostTag> Posts { get; }

        public Tag(string name)
        {
            Name = name;
            NormalizeName = name.CustomNormalize();
        }

        public void Update(string name)
        {
            Name = name;
            NormalizeName = name.CustomNormalize();
        }

	}
}
