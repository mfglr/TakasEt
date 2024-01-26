namespace Models.Entities
{
    public class Role : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public IReadOnlyCollection<UserRole> Users { get; }

        public Role(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }

    }
}
