namespace Application.Entities
{
	public class Role : Entity
	{
		public int Id { get; private set; }
        public string Name { get; private set; }
		public IReadOnlyCollection<UserRole> Users { get;}

		public override int[] GetKey()
		{
			return new[] { Id };
		}

		private Role(string name) {
			Name = name;
		}

		
	}
}
