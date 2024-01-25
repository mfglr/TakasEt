using Application.Extentions;

namespace Application.Entities
{
	public class Category : Entity,IAggregateRoot
    {
        
        public string Name { get; private set; }
        public string NormalizedName { get; private set; }
        
        public IReadOnlyCollection<Post> Posts { get; }

		public Category(string name)
		{
			Name = name;
            NormalizedName = name.CustomNormalize();
		}
        
        public void Update(string name)
        {
            Name = name;
			NormalizedName = name.CustomNormalize();
		}

	}
}
