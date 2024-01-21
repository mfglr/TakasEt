using Application.Extentions;

namespace Application.Entities
{
	public class Tag : Entity
	{
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string NormalizeName { get; private set; }
        public IReadOnlyCollection<PostTag> Posts { get; }

		public override int[] GetKey()
		{
			return new[] { Id };
		}

		public Tag(string name)
        {
            Name = name;
            NormalizeName = name.CustomNormalize()!;
        }

		
	}
}
