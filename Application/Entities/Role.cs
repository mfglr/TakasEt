namespace Application.Entities
{
	public class Role : Entity
	{
        public string Name { get; private set; }
		public IReadOnlyCollection<UserRole> Users { get;}
        
		private Role(string name) {
			Name = name;
		}
    }
}
